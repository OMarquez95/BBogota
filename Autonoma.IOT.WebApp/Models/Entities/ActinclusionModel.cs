using Autonoma.IOT.Common.Constants;
using Autonoma.IOT.Resources;
using Autonoma.IOT.WebApp.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Autonoma.IOT.WebApp.Models
{
    public class ActinclusionModel
    {

        [Display(Name = "lblSALUDO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string SALUDO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblNOMBRES", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string NOMBRES { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblAPELLIDO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string APELLIDO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblDIRECCION", ResourceType = typeof(LabelCampos))]
        [MaxLength(70, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string DIRECCION { get; set; } //	VARCHAR2(70)

        [Display(Name = "lblCIUDAD_DEPARTAMENTO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string CIUDAD_DEPARTAMENTO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblINDICATIVO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string INDICATIVO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblTELEFONO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string TELEFONO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblTIPO_DOCUMENTO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string TIPO_DOCUMENTO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblNUMERO_DOCUMENTO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string NUMERO_DOCUMENTO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblESN", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string ESN { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblCODIGO_DISTRIBUIDOR", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string CODIGO_DISTRIBUIDOR { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblCODMIN", ResourceType = typeof(LabelCampos))]
        [MaxLength(25, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        //[Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string CODMIN { get; set; } //	VARCHAR2(25)

        [Display(Name = "lblMODELO_EQUIPO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string MODELO_EQUIPO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblOCUPACION_CLIENTE", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string OCUPACION_CLIENTE { get; set; } //	VARCHAR2(50)
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "lblFECHA_NACIMIENTO", ResourceType = typeof(LabelCampos))]
        //[DataType(DataType.Date)]
        public DateTime? FECHA_NACIMIENTO { get; set; } //	DATE

        [Display(Name = "lblSEXO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string SEXO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblEMPRESA_TRABAJO_CLIENTE", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string EMPRESA_TRABAJO_CLIENTE { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblDIRECCION_EMPRESA", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string DIRECCION_EMPRESA { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblTELEFONO_EMPRESA", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TELEFONO_EMPRESA { get; set; } //	VARCHAR2(50)
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "lblFECHA_INGRESO", ResourceType = typeof(LabelCampos))]
        //[DataType(DataType.Date)]
        public DateTime? FECHA_INGRESO { get; set; } //	DATE

        [Display(Name = "lblRMIN", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? RMIN { get; set; } //	NUMBER(1)

        [Display(Name = "lblRESN", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? RESN { get; set; } //	NUMBER(3)

        [Display(Name = "lblRTAR", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? RTAR { get; set; } //	NUMBER(3)

        [Display(Name = "lblRDTC", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? RDTC { get; set; } //	NUMBER(2)

        [Display(Name = "lblRCAR", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? RCAR { get; set; } //	NUMBER(2)

        [Display(Name = "lblESTADO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string ESTADO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblSPCODE", ResourceType = typeof(LabelCampos))]
        [MaxLength(10, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string SPCODE { get; set; } //	VARCHAR2(10)

        [Display(Name = "lblTMCODE", ResourceType = typeof(LabelCampos))]
        [MaxLength(10, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TMCODE { get; set; } //	VARCHAR2(10)

        [Display(Name = "lblDISTRIBUIDOR1", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string DISTRIBUIDOR1 { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblCO_ID", ResourceType = typeof(LabelCampos))]
        //[ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public decimal? CO_ID { get; set; } //	NUMBER(22)
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "lblFECBSCS", ResourceType = typeof(LabelCampos))]
        //[DataType(DataType.DateTime)]
        public DateTime? FECBSCS { get; set; } //	DATE

        [Display(Name = "lblSCCODE", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? SCCODE { get; set; } //	NUMBER

        [Display(Name = "lblIMEI", ResourceType = typeof(LabelCampos))]
        [MaxLength(15, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string IMEI { get; set; } //	VARCHAR2(15)

        [Display(Name = "lblPRODUCTO", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? PRODUCTO { get; set; } //	NUMBER(4)

        [Display(Name = "lblEQUIPO", ResourceType = typeof(LabelCampos))]
        [MaxLength(255, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string EQUIPO { get; set; } //	VARCHAR2(255)

        [Display(Name = "lblIVA_CFM", ResourceType = typeof(LabelCampos))]
        [MaxLength(255, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string IVA_CFM { get; set; } //VARCHAR2(255)

        [Display(Name = "lblVALOR_CFM", ResourceType = typeof(LabelCampos))]
        [MaxLength(255, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string VALOR_CFM { get; set; } //	VARCHAR2(255)

        [Display(Name = "lblTIPO_CONTRATO", ResourceType = typeof(LabelCampos))]
        [MaxLength(255, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TIPO_CONTRATO { get; set; } //	VARCHAR2(255)

        [Display(Name = "lblNUMERO_CONTRATO", ResourceType = typeof(LabelCampos))]
        [MaxLength(255, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string NUMERO_CONTRATO { get; set; } //VARCHAR2(255)

        [Display(Name = "lblPLAN_TARIFAS", ResourceType = typeof(LabelCampos))]
        [MaxLength(255, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string PLAN_TARIFAS { get; set; } //	VARCHAR2(255)

        [Display(Name = "lblLINEPORACT", ResourceType = typeof(LabelCampos))]
        [MaxLength(255, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string LINEPORACT { get; set; } //	VARCHAR2(255)

        [Display(Name = "lblOCC", ResourceType = typeof(LabelCampos))]
        [MaxLength(255, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string OCC { get; set; } //	VARCHAR2(255)

        [Display(Name = "lblTOTAL_VENTA", ResourceType = typeof(LabelCampos))]
        [MaxLength(255, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TOTAL_VENTA { get; set; } //	VARCHAR2(255)

        [Display(Name = "lblTRAJO_EQUIPO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TRAJO_EQUIPO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblID_ACTINCLUSION", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? ID_ACTINCLUSION { get; set; } //	NUMBER(10)

        [Display(Name = "lblTRAJO_ICCID", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TRAJO_ICCID { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblDESTINOS_ELEG", ResourceType = typeof(LabelCampos))]
        [MaxLength(200, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string DESTINOS_ELEG { get; set; } //	VARCHAR2(200)

        [Display(Name = "lblPORCENTAJE_ELEG", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string PORCENTAJE_ELEG { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblSPCODE_PAQ", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? SPCODE_PAQ { get; set; } //	NUMBER

        [Display(Name = "lblDATOS", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? DATOS { get; set; } //	NUMBER

        public string CODMINEXT { get; set; }

        public string FECREGIS { get; set; }

        public string ROWID { get; set; }

        //Brief1779 - US41 - JLMG - Tatic - 07/2018 - Edición del campo GRUPO_CLIENTES *INI
        [Display(Name = "lblGRUPO_CLIENTES", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string GRUPO_CLIENTES { get; set; } //	VARCHAR2(50)
        //*FIN
                
    }
}