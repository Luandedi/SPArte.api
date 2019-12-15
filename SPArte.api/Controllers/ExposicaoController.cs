using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SPArte.api.Entities;
using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace SPArte.api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ExposicaoController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            Conexao conn = new Conexao();
            if (conn.mErro.Length > 0) { throw new Exception(); }
            try
            {
                string query = @"select * from exposicoes;";
                MySqlCommand cmd = new MySqlCommand(query, conn.conn);
                if (conn.OpenConexao() == false) { throw new Exception(conn.mErro); }
                DbDataReader dbDataReader = await cmd.ExecuteReaderAsync();
                var dataTable = new DataTable("exposicao");
                dataTable.Load(dbDataReader);
                string JSONString = JsonConvert.SerializeObject(dataTable);
                object JsonFormat = JsonConvert.DeserializeObject(JSONString, typeof(object));
                return Ok(JsonFormat);
            }
            catch (Exception ex)
            {
                return BadRequest(new { result = new { success = false, message = ex.Message } });

            }
            finally
            {
                conn.CloseConexao();
            }
        }

        [HttpGet]
        [Route("obrasexpostas")]
        public async Task<IActionResult> ObrasExpostas()
        {

            Conexao conn = new Conexao();
            if (conn.mErro.Length > 0) { throw new Exception(); }
            try
            {
                string query = @"SELECT controle.obra_id, controle.capa, obras.nome,obras.autor,obras.url 
                                        FROM controle
                                        INNER JOIN obras 
                                        ON controle.obra_id = obras.id";
                MySqlCommand cmd = new MySqlCommand(query, conn.conn);
                if (conn.OpenConexao() == false) { throw new Exception(conn.mErro); }
                DbDataReader dbDataReader = await cmd.ExecuteReaderAsync();
                var dataTable = new DataTable("obrasexposicao");
                dataTable.Load(dbDataReader);
                string JSONString = JsonConvert.SerializeObject(dataTable);
                object JsonFormat = JsonConvert.DeserializeObject(JSONString, typeof(object));
                return Ok(JsonFormat);
            }
            catch (Exception ex)
            {
                return BadRequest(new { result = new { success = false, message = ex.Message } });

            }
            finally
            {
                conn.CloseConexao();
            }
        }

        [HttpDelete]
        [Route("removerobrasexpostas")]
        public async Task<IActionResult> RemoverObrasExpostas()
        {
           
            Conexao DBC = new Conexao();
            if (DBC.mErro.Length > 0) { throw new Exception(); }
            try
            {

                string query = "TRUNCATE controle;";
                MySqlCommand cmd = new MySqlCommand(query, DBC.conn);
                if (DBC.OpenConexao() == false) { throw new Exception(DBC.mErro); }
                await cmd.ExecuteNonQueryAsync();             

                return Ok(new { result = new { success = true, message = "Obras removidas da exposição." } });

            }
            catch (Exception ex)
            {
                return BadRequest(new { result = new { success = false, message = ex.Message } });
            }
            finally
            {
                DBC.CloseConexao();
            }

        }
    }
}