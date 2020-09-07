using Autonoma.IOT.Resources;
using Autonoma.IOT.WebApp.Helpers;
using System.ComponentModel.DataAnnotations;
using Autonoma.IOT.Common.Constants;
using System;

namespace Autonoma.IOT.WebApp.Models
{
    public class MigracionModel
    {

        [Display(Name = "lblICCID", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string ICCID { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblIMEI", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string IMEI { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblMSISDN", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string MSISDN { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblCO_ID", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? CO_ID { get; set; } //	NUMBER

        [Display(Name = "lblTMCODE", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? TMCODE { get; set; } //	NUMBER

        [Display(Name = "lblSPCODE", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? SPCODE { get; set; } //	NUMBER

        [Display(Name = "lblFECHA_CORTE", ResourceType = typeof(LabelCampos))]
        [MaxLength(2, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        //[DataType(DataType.Date)]
        public string FECHA_CORTE { get; set; } //	VARCHAR2(2)

        [Display(Name = "lblDISTRIBUIDOR", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string DISTRIBUIDOR { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblDISTRIBUIDOR_MIGRACION", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string DISTRIBUIDOR_MIGRACION { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblCOMSEGURO", ResourceType = typeof(LabelCampos))]
        [MaxLength(2, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string COMSEGURO { get; set; } //	VARCHAR2(2)

        [Display(Name = "lblMODELO_IMEI", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string MODELO_IMEI { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblCFM", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? CFM { get; set; } //	NUMBER

        [Display(Name = "lblIVA_CFM", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? IVA_CFM { get; set; } //	NUMBER

        [Display(Name = "lblVLR_EQUIPO", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? VLR_EQUIPO { get; set; } //	NUMBER

        [Display(Name = "lblF_PAGO", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? F_PAGO { get; set; } //	NUMBER

        [Display(Name = "lblIVA_EQUIPO", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? IVA_EQUIPO { get; set; } //	NUMBER

        [Display(Name = "lblVLR_SIM", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? VLR_SIM { get; set; } //	NUMBER

        [Display(Name = "lblIVA_SIM", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? IVA_SIM { get; set; } //	NUMBER

        [Display(Name = "lblTOTAL_VENTA", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? TOTAL_VENTA { get; set; } //	NUMBER

        [Display(Name = "lblESN", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string ESN { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblESTADO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string ESTADO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblOCC", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        public decimal? OCC { get; set; } //NUMBER
        [Display(Name = "lblTIPO_CONTRATO", ResourceType = typeof(LabelCampos))]
        [ValidDecimal(ErrorMessage = Parameters.SOLO_DECIMALES)]
        //[DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? TIPO_CONTRATO { get; set; } //	NUMBER

        [Display(Name = "lblRESN", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? RESN { get; set; } //	NUMBER(3)

        [Display(Name = "lblPERMANENCIA", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? PERMANENCIA { get; set; } //	NUMBER(3)

        [Display(Name = "lblID_MIGRACION", ResourceType = typeof(LabelCampos))]
        [ValidInteger(ErrorMessage = Parameters.SOLO_ENTEROS)]
        public int? ID_MIGRACION { get; set; } //	NUMBER(10)

        [Display(Name = "lblNUMERO_DOCUMENTO", ResourceType = typeof(LabelCampos))]
        [MaxLength(50, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string NUMERO_DOCUMENTO { get; set; } //	VARCHAR2(50)

        [Display(Name = "lblNOMBRE_CLIENTE", ResourceType = typeof(LabelCampos))]
        [MaxLength(255, ErrorMessageResourceName = "TamanioCampo", ErrorMessageResourceType = typeof(Generales))]
        public string NOMBRE_CLIENTE { get; set; } //	VARCHAR2(255)
        public string MOTIVO_RECHAZO { get; set; }
        public string CODMINEXT { get; set; }
        public DateTime FECREGIS { get; set; }
        public string ROWID { get; set; }


    }
}