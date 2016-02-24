using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using Loja.Classes;
using Microsoft.Data.OData;

namespace LojaAPI.Controllers
{
    public class ClientesController : ApiController
    {

        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Clientes
        public async Task<IHttpActionResult> GetClientes([FromUri]string sort, [FromUri]string order)
        {
            // validate the query.
            try
            {
                //queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }
            List<Cliente> re = new Cliente().GetAll();
            if (order == "asc")
            {
                switch (sort)
                {
                    case "Codigo":
                        re = re.OrderBy(o => o.Codigo).ToList();
                        break;
                    case "Nome":
                        re = re.OrderBy(o => o.Nome).ToList();
                        break;
                    case "DataCadastro":
                        re = re.OrderBy(o => o.DataCadastro).ToList();
                        break;
                    default:
                        break;
                }
            }
            else if (order == "desc")
            {
                switch (sort)
                {
                    case "Codigo":
                        re = re.OrderByDescending(o => o.Codigo).ToList();
                        break;
                    case "Nome":
                        re = re.OrderByDescending(o => o.Nome).ToList();
                        break;
                    case "DataCadastro":
                        re = re.OrderByDescending(o => o.DataCadastro).ToList();
                        break;
                    default:
                        break;
                }
            }
            return Ok(re);
        }

        // GET: odata/Clientes(5)
        public async Task<IHttpActionResult> GetCliente([FromODataUri] int key, ODataQueryOptions<Cliente> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Cliente>(cliente);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Clientes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Cliente> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(cliente);

            // TODO: Save the patched entity.

            // return Updated(cliente);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Clientes
        public async Task<IHttpActionResult> Post(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(cliente);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Clientes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Cliente> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(cliente);

            // TODO: Save the patched entity.

            // return Updated(cliente);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Clientes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
