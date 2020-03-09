using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ClienteWeb.Models;
using MySql.Data.MySqlClient;

namespace ClienteWeb.Dao
{
    
    public class ClienteDao
    {
        private DataSet ds = new DataSet();
        private MySqlConnection cn = new MySqlConnection("Server=localhost;USER Id=root;PASSWORD='';DataBase=db_empresa");
        private MySqlCommand cm;
        private string Sqlcomand;

        public void Adicionar(Cliente cliente)
        {
            Sqlcomand = $"INSERT INTO clientes (Identificacao, Nome, CPF) VALUES (?,?,?)";
            cm = new MySqlCommand(Sqlcomand, cn);
            cm.Parameters.AddWithValue("@Identificacao", cliente.Identificacao);
            cm.Parameters.AddWithValue("@Nome", cliente.Nome);
            cm.Parameters.AddWithValue("@CPF", cliente.CPF);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        public void Atualizar(Cliente cliente)
        {
            Sqlcomand = $"UPDATE clientes SET Nome=@Nome, CPF=@CPF  WHERE Identificacao=@Identificacao";
            cm = new MySqlCommand(Sqlcomand, cn);
            cm.Parameters.AddWithValue("@Nome", cliente.Nome);
            cm.Parameters.AddWithValue("@CPF", cliente.CPF);
            cm.Parameters.AddWithValue("@Identificacao", cliente.Identificacao);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        public void Deletar(Cliente cliente)
        {
            Sqlcomand = $"DELETE FROM clientes WHERE Identificacao=@Identificacao";
            cm = new MySqlCommand(Sqlcomand, cn);
            cm.Parameters.AddWithValue("@Identificacao", cliente.Identificacao);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            
        }
    
        // Consultando apenas um
        /*public void Consultar(Cliente cliente)
        {
            Sqlcomand = $"SELECT * FROM clientes WHERE Identificacao=@Identificacao";
            cm = new MySqlCommand(Sqlcomand, cn);
            cm.Parameters.AddWithValue("@Identificacao", cliente.Identificacao);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }*/

        // Consultando TODOS
        public List<Cliente> Consultar()
        {
            List<Cliente> clientes = new List<Cliente>();

            Sqlcomand = $"SELECT * FROM clientes";
            cm = new MySqlCommand(Sqlcomand, cn);
            cn.Open();
            cm.ExecuteNonQuery();

            MySqlDataReader reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente()
                {
                    CPF = (string)reader["CPF"],
                    Nome = (string)reader["Nome"],
                    Identificacao = (int)reader["Identificacao"],
                };
                clientes.Add(cliente);
            }
            cn.Close();
            return clientes;
        }

        
    }
}