using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class DadosInscricao
    {
        public string Nome_Estudante { get; set; }
        public string Nome_Pai { get; set; }
        public string Nome_Mae { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Naturalidade { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string Nacionalidade { get; set; }
        public string Num_BI { get; set; }
        public DateTime Data_Emissao { get; set; }
        public string Local_Emissão { get; set; }

        [Num_BI] [varchar] (100) NOT NULL,
 
     [Nome_Candidato] [varchar] (150) NOT NULL,
  
      [Nome_Pai] [varchar] (150) NOT NULL,
   
       [Nome_Mae] [varchar] (150) NOT NULL,
    
        [Sexo] [varchar] (15) NOT NULL,
     
         [Residencia] [varchar] (150) NOT NULL,
      
          [CasaNum] [varchar] (15) NOT NULL,
       
           [Bairro] [varchar] (50) NOT NULL,
        
            [Data_Nascimento] [date]
        NOT NULL,
        
            [Naturalidade] [varchar] (50) NOT NULL,
         
             [Provincia] [varchar] (100) NOT NULL,
          
              [Municipio] [varchar] (100) NOT NULL,
           
               [Nacionalidade] [varchar] (150) NULL,
	[Data_EmiBI] [date] NULL,
	[Local_EmiBI] [varchar] (150) NULL,
    }
}
