using Autonoma.IOT.Common.Constants;
using Autonoma.IOT.Resources;
using Autonoma.IOT.WebApp.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autonoma.IOT.WebApp.Models
{
    public class ActivacionpreModel
    {

        [Display(Name = "lblSALUDO", ResourceType = typeof(LabelCampos))]
        [MaxLength(5, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string SALUDO { get; set; } //		VARCHAR2(5)

        [Display(Name = "lblNOMBRES", ResourceType = typeof(LabelCampos))]
        [MaxLength(40, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string NOMBRES { get; set; } //		VARCHAR2(40)

        [Display(Name = "lblAPELLIDO", ResourceType = typeof(LabelCampos))]
        [MaxLength(40, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string APELLIDO { get; set; } //		VARCHAR2(40)

        [Display(Name = "lblNUMERO_DOCUMENTO", ResourceType = typeof(LabelCampos))]
        [MaxLength(20, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string NUMERO_DOCUMENTO { get; set; } //		VARCHAR2(20)

        [Display(Name = "lblTELEFONO", ResourceType = typeof(LabelCampos))]
        [MaxLength(20, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TELEFONO { get; set; } //		VARCHAR2(20)

        [Display(Name = "lblDIRECCION", ResourceType = typeof(LabelCampos))]
        [MaxLength(70, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string DIRECCION { get; set; } //		VARCHAR2(70)

        [Display(Name = "lblCIUDAD_DEPARTAMENTO", ResourceType = typeof(LabelCampos))]
        [MaxLength(40, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string CIUDAD_DEPARTAMENTO { get; set; } //		VARCHAR2(40)

        [Display(Name = "lblICCID", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string ICCID { get; set; } //		VARCHAR2(50)

        [Display(Name = "lblIMEI", ResourceType = typeof(LabelCampos))]
        [MaxLength(15, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string IMEI { get; set; } //		VARCHAR2(15)

        [Display(Name = "lblTECNOLOGIA", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? TECNOLOGIA { get; set; } //		NUMBER

        [Display(Name = "lblCODIGO_DISTRIBUIDOR", ResourceType = typeof(LabelCampos))]
        [MaxLength(24, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string CODIGO_DISTRIBUIDOR { get; set; } //		VARCHAR2(24)

        [Display(Name = "lblUSUARIO", ResourceType = typeof(LabelCampos))]
        [MaxLength(20, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string USUARIO { get; set; } //		VARCHAR2(20)

        [Display(Name = "lblTMCODE", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? TMCODE { get; set; } //		NUMBER

        [Display(Name = "lblSPCODE", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? SPCODE { get; set; } //		NUMBER

        [Display(Name = "lblCODMIN", ResourceType = typeof(LabelCampos))]
        [MaxLength(20, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        //[Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string CODMIN { get; set; } //		VARCHAR2(20)

        [Display(Name = "lblCENTRO_COSTO", ResourceType = typeof(LabelCampos))]
        [MaxLength(30, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string CENTRO_COSTO { get; set; } //		VARCHAR2(30)

        [Display(Name = "lblRESN", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? RESN { get; set; } //		NUMBER

        [Display(Name = "lblRTAR", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? RTAR { get; set; } //		NUMBER

        [Display(Name = "lblESTADO", ResourceType = typeof(LabelCampos))]
        [MaxLength(15, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        [Required(ErrorMessageResourceType = typeof(Generales), ErrorMessageResourceName = "CampoRequerido")]
        public string ESTADO { get; set; } //		VARCHAR2(15)

        [Display(Name = "lblESTADOIN", ResourceType = typeof(LabelCampos))]
        [MaxLength(15, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string ESTADOIN { get; set; } //		VARCHAR2(15)

        [Display(Name = "lblCO_ID", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? CO_ID { get; set; } //		NUMBER(22)

        [Display(Name = "lblCUSTOMER_ID", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? CUSTOMER_ID { get; set; } //		NUMBER(22)

        [Display(Name = "lblESTADOMO", ResourceType = typeof(LabelCampos))]
        [MaxLength(15, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string ESTADOMO { get; set; } //		VARCHAR2(15)

        [Display(Name = "lblNOMBRE_EQUIPO", ResourceType = typeof(LabelCampos))]
        [MaxLength(100, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string NOMBRE_EQUIPO { get; set; } //		VARCHAR2(100)

        [Display(Name = "lblID_ACTIVACION", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? ID_ACTIVACION { get; set; } //		NUMBER

        [Display(Name = "lblINDICATIVO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string INDICATIVO { get; set; } //		VARCHAR2(50)

        [Display(Name = "lblTIPO_DOCUMENTO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string TIPO_DOCUMENTO { get; set; } //		VARCHAR2(50)

        [Display(Name = "lblSEXO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string SEXO { get; set; } //		VARCHAR2(50)

        [Display(Name = "lblID_VENDEDOR", ResourceType = typeof(LabelCampos))]
        [MaxLength(15, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string ID_VENDEDOR { get; set; } //		VARCHAR2(15)
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "lblFECHA_VENTA", ResourceType = typeof(LabelCampos))]
        //[DataType(DataType.Date)]
        public DateTime? FECHA_VENTA { get; set; }

        [Display(Name = "lblGENERAR_TICKLER", ResourceType = typeof(LabelCampos))]
        [MaxLength(200, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string GENERAR_TICKLER { get; set; } //		VARCHAR2(200)

        [Display(Name = "lblACTUALIZACION_BDO", ResourceType = typeof(LabelCampos))]
        [Range(0,9, ErrorMessageResourceName = "RangoCampo", ErrorMessageResourceType = typeof(Generales))]
        public int ACTUALIZACION_BDO { get; set; } //		NUMBER(1)

        public DateTime? FECREGIS { get; set; }

        public string ROWID { get; set; }

        //Brief1779 - US41 - JLMG - Tatic - 07/2018 - Edición del campo GRUPO_CLIENTES *INI
        [Display(Name = "lblGRUPO_CLIENTES", ResourceType = typeof(LabelCampos))]
        [MaxLength(10, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string GRUPO_CLIENTES { get; set; } //	VARCHAR2(10)
        //*FIN

        //Brief1779 - US42 - JLMG - Tatic - 07/2018 - Edición del campo PLANILLA *INI
        [Display(Name = "lblPLANILLA", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string PLANILLA { get; set; } //	VARCHAR2(50)
        //*FIN

    }
}