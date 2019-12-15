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
    public class ObrasController : ControllerBase
    {
        // GET api/obras @Async para liberar recursos na maquina e nao ficar aguardando o servidor@
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            Conexao conn = new Conexao();
            if (conn.mErro.Length > 0) { throw new Exception(); }
            try
            {
                string query = @"select * from obras;";
                MySqlCommand cmd = new MySqlCommand(query, conn.conn);
                if (conn.OpenConexao() == false) { throw new Exception(conn.mErro); }
                DbDataReader dbDataReader = await cmd.ExecuteReaderAsync();
                var dataTable = new DataTable("obras");
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

        // GET api/obras/1
        [HttpGet("{id}")]
        public async Task<ActionResult>GetByID(int id)
        {
            Conexao conn = new Conexao();
            if (conn.mErro.Length > 0) { throw new Exception(); }
            try
            {
                string query = @"select * from obras where id ="+id+";";
                MySqlCommand cmd = new MySqlCommand(query, conn.conn);
                if (conn.OpenConexao() == false) { throw new Exception(conn.mErro); }
                DbDataReader dbDataReader = await cmd.ExecuteReaderAsync();
                var dataTable = new DataTable("obras");
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


        [HttpPost]
        [Route("gravarobras")]       
        public async Task<IActionResult> Index([FromBody] dynamic data)
        {       
            int capa = data.capa;
            Conexao DBC = new Conexao();
            if (DBC.mErro.Length > 0) { throw new Exception(); }
            try
            {              


                string query = "insert into controle(obra_id, exposicao_id, capa)" +
                                " values (@obra_id,@exposicao_id,@capa)" +
                                                    "on duplicate key update " +
                                                    "exposicao_id = @exposicao_id," +
                                                    "capa = @capa;";


                MySqlCommand cmd = new MySqlCommand(query, DBC.conn);
                if (DBC.OpenConexao() == false) { throw new Exception(DBC.mErro); }

                foreach (var u in data.obras)
                {  
                   
                    cmd.Parameters.AddWithValue("@obra_id", u.id);
                    cmd.Parameters.AddWithValue("@exposicao_id", 1);
                    cmd.Parameters.AddWithValue("@capa",capa==Convert.ToInt32(u.id)?"S":"N");
                    await cmd.ExecuteNonQueryAsync();
                    cmd.Parameters.Clear();
                   
                }     

                return Ok(new { result = new { success = true, message = "Obras enviadas para exposição!" } });

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