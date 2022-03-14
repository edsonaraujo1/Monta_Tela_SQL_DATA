using Script_Buscar_Tabelas.DataBase;
using Script_Buscar_Tabelas.Models;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Script_Buscar_Tabelas
{
    class Program
    {
        static void Main(string[] args)
        {
            PropertyInfo[] propre = typeof(TB_BANCOS).GetProperties();
            string campo_tab = "";
            using (var contexto = new Contexto())
            {
                int     ix              = 0;
                int     len             = 0;
                int     s               = 0;
                string  nos             = "";
                string  aTabela         = "TB_BANCOS";
                string  campo_busca     = "NR_001"; // CODIGOD_CLIENTE
                string  Nome_Coluna     = "";
                string  Tipo_Campo      = "";
                string  Null_Campo      = "";
                string  Tamanho_Campo   = "";
                string  novo_str2       = "";
                string  DisplayName     = "";
                int     quant           = 0;
                char    tipo;
                string  ID              = "00000100730"; 

                Console.WriteLine("INFORME CODIGOD_CLIENTE");
                ID = Console.ReadLine();
                Console.WriteLine("\n");

                string[] linhas = Console.ReadLine().Split(',');
                quant = int.Parse(linhas[0]);
                tipo = char.Parse(linhas[1]);
                ID = linhas[2];

                Console.WriteLine("Valores Digitados: " + quant + "|" + tipo + "|" + ID + "\n");

                try
                {
                    foreach (var item in propre)
                    {
                        if (len == 0)
                        {
                            nos += item.Name;
                        }
                        else
                        {
                            nos += ", " + item.Name;
                        }
                        len++;
                    }

                    campo_tab = nos;

                    string novo_str = campo_tab.Substring(0, (campo_tab.Length - 0));

                    string[] itemValor = novo_str.Split(new char[] { ' ', ',', '#' }, StringSplitOptions.RemoveEmptyEntries);
                    var array = new string[itemValor.Length];
                    for (int i = 0; i < itemValor.Length; i++)
                    {
                        novo_str2 += "" + itemValor[i] + ", ";
                        ix++;
                    }

                    string strQueryString = string.Format("SELECT TOP " + ix + "COLUMN_NAME, IS_NULLABLE, DATA_TYPE, NUMERIC_PRECISION, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + aTabela + "'");
                    using (SqlDataReader reader1 = contexto.ExecutaComandoComRetorno(strQueryString))
                    {
                        while (reader1.Read())
                        {
                            Nome_Coluna = reader1["COLUMN_NAME"].ToString();
                            Tipo_Campo = reader1["DATA_TYPE"].ToString();
                            Null_Campo = reader1["IS_NULLABLE"].ToString();
                            if(Tipo_Campo == "int" || Tipo_Campo == "smallint")
                            {
                                Tamanho_Campo = reader1["NUMERIC_PRECISION"].ToString();
                            }
                            else
                            {
                                Tamanho_Campo = reader1["CHARACTER_MAXIMUM_LENGTH"].ToString();
                            }
                            
                            Console.WriteLine("Nome do Campo Modelo: " + itemValor[s].ToString());
                            Console.WriteLine("Nome do Campo: " + Nome_Coluna);
                            Console.WriteLine("Tipo de Campo: " + Tipo_Campo);
                            Console.WriteLine("Permite Nulo: " + Null_Campo);
                            Console.WriteLine("Tamanho da Campo: " + Tamanho_Campo.ToString() + "\n");
                            s++;
                        }
                        
                        string strQuery_tabela = string.Format("SELECT * FROM " + aTabela + " WHERE "+ campo_busca + " = '" + ID + "'");
                        SqlDataReader dados = contexto.ExecutaComandoComRetorno(strQuery_tabela);
                        dados.Read();

                        for (int w = 0; w < itemValor.Length; w++)
                        {
                            string ss = itemValor[w].ToString();
                            MemberInfo property = typeof(TB_BANCOS).GetProperty(ss);
                            if (property.CustomAttributes.Count() != 0)
                            {
                                var attibute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single();
                                DisplayName = attibute.DisplayName;
                            }
                            Nome_Coluna = itemValor[w];
                            if (itemValor.Contains(Nome_Coluna))
                            {
                                Console.WriteLine("Conteudo de {0,20}: {1,21} - {2}", Nome_Coluna, DisplayName, dados[Nome_Coluna].ToString());
                            }
                        }

                        Console.ReadLine();

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
            }
        }
    }
}