using System;
using System.ComponentModel;

namespace Script_Buscar_Tabelas.Models
{
    public class TB_BANCOS
    {
        [DisplayName("Nº ISPB")]
        public int NR_ISPB { get; set; }

        [DisplayName("Nome Banco")]
        public string DE_BANCO { get; set; }

        [DisplayName("Código Banco")]
        public int CD_BANCO { get; set; }

        [DisplayName("Compensação")]
        public string FL_COMPENSACAO { get; set; }

        [DisplayName("Nome Completo")]
        public string DE_NOME_COMPLETO { get; set; }

        [DisplayName("Data Operação")]
        public DateTime DT_OPERACAO { get; set; }
    }
}
