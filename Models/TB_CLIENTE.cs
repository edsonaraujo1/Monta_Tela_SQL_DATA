using System.ComponentModel;

namespace Script_Buscar_Tabelas.Models
{
    public class TB_CLIENTE
    {
        [DisplayName("Código Cliente")]
        public string CD_CLIENTE { get; set; }


        [DisplayName("CD Usuário")]
        public string CD_USUARIO { get; set; }


        [DisplayName("Data Cadastro")]
        public string DT_CADASTRO { get; set; }

        [DisplayName("Data Ultima Alteração")]
        public string DT_ULT_ALTERACAO { get; set; }

        [DisplayName("Qtd Risco")]
        public string QT_RISCO { get; set; }


        [DisplayName("CD Situação")]
        public string CD_SITUACAO { get; set; }

        [DisplayName("CD Grupo Cliente")]
        public string CD_GRUPO_CLIENTE { get; set; }

        [DisplayName("Nome do Cliente")]
        public string DE_CLIENTE { get; set; }

        [DisplayName("CPF/CNPJ")]
        public string CIC_CPF { get; set; }

        [DisplayName("CPF/CNPJ-NRO")]
        public string CPF_CNPJ_NRO { get; set; }

    }
}
