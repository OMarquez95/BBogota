using Autonoma.IOT.Resources;
using Autonoma.IOT.WebApp.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using Autonoma.IOT.Common.Constants;

namespace Autonoma.IOT.WebApp.Models
{
    public class ActivacionModel
    {
        
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
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        //[Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string CODMIN { get; set; } //	VARCHAR2(50)

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "lblFECHA_VENTA", ResourceType = typeof(LabelCampos))]
        //[DataType(DataType.Date)]
        public DateTime? FECHA_VENTA { get; set; } //	DATE

        [Display(Name = "lblVALOR_CFM", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string VALOR_CFM { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblIVA_CFM", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string IVA_CFM { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblEQUIPO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string EQUIPO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblIVA_EQUIPO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string IVA_EQUIPO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblTOTAL_VENTA", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TOTAL_VENTA { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblNUMERO_CONTRATO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string NUMERO_CONTRATO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblMODELO_EQUIPO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        //[Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string MODELO_EQUIPO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblTIPO_CONTRATO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TIPO_CONTRATO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblCOMSEGURO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string COMSEGURO { get; set; } //	VARCHAR2(50)

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

        [Display(Name = "lblCENTRO_COSTO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string CENTRO_COSTO { get; set; } //	VARCHAR2(50)

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
        public DateTime? FECHA_INGRESO { get; set; } //	DATE

        [Display(Name = "lblRMIN", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? RMIN { get; set; } //	NUMBER(1)

        [Display(Name = "lblRESN", ResourceType = typeof(LabelCampos))]
        //[ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
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

        [Display(Name = "lblLINEACT", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string LINEACT { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblLINEPORACT", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string LINEPORACT { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblTRAJO_EQUIPO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TRAJO_EQUIPO { get; set; } //	VARCHAR2(50)

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
        public decimal? CO_ID { get; set; } //	NUMBER(22)

        [Display(Name = "lblSCCODE", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public decimal? SCCODE { get; set; } //	NUMBER

        [Display(Name = "lblIMEI", ResourceType = typeof(LabelCampos))]
        [MaxLength(15, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string IMEI { get; set; } //	VARCHAR2(15)

        [Display(Name = "lblTRAJO_ICCID", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TRAJO_ICCID { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblOCC", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? OCC { get; set; } //	NUMBER(7)

        [Display(Name = "lblOBSERVACION", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string OBSERVACION { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblCONSECUTIVO", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? CONSECUTIVO { get; set; } //	NUMBER

        [Display(Name = "lblPRODUCTO", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? PRODUCTO { get; set; } //	NUMBER(4)

        [Display(Name = "lblVALOR_PAGAR", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? VALOR_PAGAR { get; set; } //	NUMBER(8)

        [Display(Name = "lblVALOR_PAGARSIM", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? VALOR_PAGARSIM { get; set; } //	NUMBER(6)

        [Display(Name = "lblIMEIOFQ", ResourceType = typeof(LabelCampos))]
        [MaxLength(15, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string IMEIOFQ { get; set; } //	VARCHAR2(15)

        [Display(Name = "lblMODELO_EQUIPO_OFQ", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string MODELO_EQUIPO_OFQ { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblCICLO_CORPORATIVO", ResourceType = typeof(LabelCampos))]
        [MaxLength(1, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string CICLO_CORPORATIVO { get; set; } //	VARCHAR2(1)

        [Display(Name = "lblVALOR_EQUIPO_ESPECIAL", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string VALOR_EQUIPO_ESPECIAL { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblVALOR_IVA_EQUIPO_ESPECIAL", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string VALOR_IVA_EQUIPO_ESPECIAL { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblVALOR_ICCID_ESPECIAL", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string VALOR_ICCID_ESPECIAL { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblVALOR_IVA_ICCID_ESPECIAL", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string VALOR_IVA_ICCID_ESPECIAL { get; set; } //	VARCHAR2(50)
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "lblFECHA_PRIMERA_CARGA", ResourceType = typeof(LabelCampos))]
        //[DataType(DataType.Date)]
        public DateTime? FECHA_PRIMERA_CARGA { get; set; } //	DATE

        [Display(Name = "lblID_ACTIVACION", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? ID_ACTIVACION { get; set; } //	NUMBER(10)
        public string CODMINEXT { get; set; }

        public DateTime FECREGIS { get; set; }
        public string ROWID { get; set; }

        //Brief1779 - US41 - JLMG - Tatic - 07/2018 - Edición del campo GRUPO_CLIENTES *INI
        [Display(Name = "lblGRUPO_CLIENTES", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string GRUPO_CLIENTES { get; set; } //	VARCHAR2(50)
        //*FIN

        //Brief1779 - US42 - JLMG - Tatic - 07/2018 - Edición del campo PLANILLA *INI
        [Display(Name = "lblPLANILLA", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string PLANILLA { get; set; } //	VARCHAR2(50)
        //*FIN
    }
}