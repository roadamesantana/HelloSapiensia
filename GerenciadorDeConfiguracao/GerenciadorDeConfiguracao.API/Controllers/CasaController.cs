using GerenciadorDeConfiguracao.Data;
using GerenciadorDeConfiguracao.Domain;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GerenciadorDeConfiguracao.API.Controllers
{
    [RoutePrefix("api")]
    public class CasaController : ApiController
    {
        private GerenciadorDeConfiguracaoDataContext db = new GerenciadorDeConfiguracaoDataContext();

        [Authorize()]
        [Route("casas")]
        public HttpResponseMessage GetCasas()
        {
            var resultado = db.Casas.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }

        [Route("funcoes")]
        public HttpResponseMessage GetFuncoes()
        {
            var resultado = db.Funcoes.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }

        [Route("casa/{casaId}/funcoes")]
        public HttpResponseMessage GetCasaFuncao(int casaId)
        {
            var resultado = db.Funcoes.Where(x => x.CasaId == casaId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }

        [Route("funcoes")]
        [HttpPost]
        public HttpResponseMessage PostFuncao(Funcao funcao)
        {
            if (null == funcao)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Funcoes.Add(funcao);
                db.SaveChanges();

                var resultado = funcao;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch(Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível incluir.");
            }
        }

        [Route("casas")]
        [HttpPost]
        public HttpResponseMessage PostCasa(Casa casa)
        {
            if (null == casa)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Casas.Add(casa);
                db.SaveChanges();

                var resultado = casa;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível incluir.");
            }
        }

        [Route("funcoes")]
        [HttpDelete]
        public HttpResponseMessage DeleteFuncao(int funcaoId)
        {
            if (funcaoId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Funcoes.Remove(db.Funcoes.Find(funcaoId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Excluido");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível excluir.");
            }
        }

        [Route("casas")]
        [HttpDelete]
        public HttpResponseMessage DeleteCasa(int casaId)
        {
            if (casaId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Casas.Remove(db.Casas.Find(casaId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Excluido");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível excluir.");
            }
        }

        [Route("funcoes")]
        [HttpPut]
        public HttpResponseMessage PutFuncao(Funcao funcao)
        {
            if (null == funcao)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Entry<Funcao>(funcao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var resultado = funcao;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível editar.");
            }
        }

        [Route("casas")]
        [HttpPut]
        public HttpResponseMessage PutCasa(Casa casa)
        {
            if (null == casa)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Entry<Casa>(casa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var resultado = casa;

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível editar.");
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}