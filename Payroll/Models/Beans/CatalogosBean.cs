using System;

namespace Payroll.Models.Beans
{
    public class CatalogosBean
    {
    }
    public class CatalogoGeneralBean
    {
        public int iId { get; set; }
        public int iCampoCatalogoId { get; set; }
        public int iIdValor { get; set; }
        public string sValor { get; set; }
        public string sDescripcion { get; set; }
        public int iCancelado { get; set; }
        public int iIdUsuAlta { get; set; }
        public string sFechaAlta { get; set; }
        public string sMensaje { get; set; }
    }
    public class InfDomicilioBean
    {

        // Beans catalogo general estados \\
        public int iId { get; set; }
        public int iIdValor { get; set; }
        public string sValor { get; set; }
        public int iIdCodigoPostal { get; set; }
        public string sCiudad { get; set; }
        public int iIdColonia { get; set; }
        public string sColonia { get; set; }
        public int iIdMunicipio { get; set; }
        public string sMensaje { get; set; }
    }
    public class InfoDireccionByCPBean
    {
        public int iIdEstado { get; set; }
        public string sEstado { get; set; }
        public int iIdMunicipio { get; set; }
        public string sMunicipio { get; set; }
        public int iIdColonia { get; set; }
        public string sDelegacion { get; set; }
        public string sColonia { get; set; }
        public string sCiudad { get; set; }
    }
    public class NivelEstudiosBean
    {
        public int iIdNivelEstudio { get; set; }
        public string sNombreNivelEstudio { get; set; }
        public int iEstadoNivelEstudio { get; set; }
        public string sUsuarioRegistroNivel { get; set; }
        public string sFechaRegistroNivel { get; set; }
        public string sUsuarioModificaNivel { get; set; }
        public string sFechaModificaNivel { get; set; }
        public string sMensaje { get; set; }
    }
    public class TipoSangreBean
    {
        public int iIdTipoSangre { get; set; }
        public string sNombreTipoSangre { get; set; }
        public int iEstadoTipoSangre { get; set; }
        public string sUsuarioRegistroTipo { get; set; }
        public string sFechaRegistroTipo { get; set; }
        public string sUsuarioModificaTipo { get; set; }
        public string sFechaModificaTipo { get; set; }
        public string sMensaje { get; set; }
    }
    public class TabuladoresBean
    {
        public int iIdTabulador { get; set; }
        public string sTabulador { get; set; }
        public int iEstadoTabulador { get; set; }
        public string sUsuarioRegistroTabulador { get; set; }
        public string sFechaRegistroTabulador { get; set; }
        public string sUsuarioModificaTabulador { get; set; }
        public string sFechaModificaTabulador { get; set; }
        public string sMensaje { get; set; }
    }
    public class BancosBean
    {
        public int iIdBanco { get; set; }
        public string sNombreBanco { get; set; }
        public int iClave { get; set; }
        public int iEstadoBanco { get; set; }
        public string sUsuarioRegistroBanco { get; set; }
        public string sFechaRegistroBanco { get; set; }
        public string sUsuarioModificaBanco { get; set; }
        public string sFechaModificaBanco { get; set; }
        public string sMensaje { get; set; }
    }
    public class PuestosBean
    {
        public int iIdPuesto { get; set; }
        public int iIdEmpresa { get; set; }
        public string sNombrePuesto { get; set; }
        public string sDescripcionPuesto { get; set; }
        public int iIdProfesionFamilia { get; set; }
        public int iIdEtiquetaContable { get; set; }
        public string sOcupacionPuesto { get; set; }
        public int iIdClasificacionPuesto { get; set; }
        public int iIdColectivo { get; set; }
        public int iIdClaveSat { get; set; }
        public int iIdNivelJerarquico { get; set; }
        public int iIdPerfomanceManager { get; set; }
        public int iIdTabulador { get; set; }
        public string sSindicato { get; set; }
        public string sGradoDominio { get; set; }
        public string sTarjetaPres { get; set; }
        public int iEstadoPuesto { get; set; }
        public string sUsuarioRegistroPuesto { get; set; }
        public string sFechaRegistroPuesto { get; set; }
        public string sMensaje { get; set; }
    }
    public class ProfesionesFamiliaBean
    {
        public int iIdProfesionFamilia { get; set; }
        public string sNombreProfesion { get; set; }
        public int iEstadoProfesion { get; set; }
        public string sUsuarioRegistroProfesion { get; set; }
        public string sFechaRegistroProfesoin { get; set; }
    }
    public class EtiquetasContablesBean
    {
        public int iIdEtiquetaContable { get; set; }
        public string sNombreEtiquetaContable { get; set; }
        public int iEstadoEtiquetaContable { get; set; }
        public string sUsuarioRegistroEtiqueta { get; set; }
        public string sFechaRegistroEtiqueta { get; set; }
    }
    public class NivelJerarBean
    {
        public int iIdNivelJerarquico { get; set; }
        public string sNombreNivelJerarquico { get; set; }
        public int iEstadoNivelJerarquico { get; set; }
        public string sUsuarioRegistroNivel { get; set; }
        public string sFechaRegistroNivel { get; set; }
    }
    public class PerfomanceManagerBean
    {
        public int iIdPerfomanceManager { get; set; }
        public string sPerfomanceManager { get; set; }
        public int iEstadoPerfomance { get; set; }
        public string sUsuarioRegistroPerfomance { get; set; }
        public string sFechaRegistroPerfomance { get; set; }
    }
    public class EmpresasBean
    {
        public int iIdEmpresa { get; set; }
        public string sNombreEmpresa { get; set; }
        public string sRazonSocial { get; set; }
        public int iIdEstado { get; set; }
        public int iIdCiudad { get; set; }
        public string sCalle { get; set; }
        public string sGiro { get; set; }
        public string fRfc { get; set; }
        public int iIdRegistroPatronal { get; set; }
        public int iNominaAutomaticaUltimo { get; set; }
        public int iNominaAutomaticaInicial { get; set; }
        public int iNominaAutomaticaFinal { get; set; }
        public string sSueldoPeriodo { get; set; }
        public string sPagoSueldo { get; set; }
        public int iEstadoEmpresa { get; set; }
        public string sUsuarioRegistro { get; set; }
        public string sFechaRegistro { get; set; }
        public string sMensaje { get; set; }
    }
    public class CentrosCostosBean
    {
        public int iIdCentroCosto { get; set; }
        public int iIdEmpresa { get; set; }
        public string sCentroCosto { get; set; }
        public string sDescripcionCentroCosto { get; set; }
        public int iEstadoCentroCosto { get; set; }
        public string sUsuarioRegistroCentro { get; set; }
        public string sFechaRegistroCentro { get; set; }
        public string sMensaje { get; set; }
    }
    public class EdificiosBean
    {
        public int iIdEdificio { get; set; }
        public int iEstado_id { get; set; }
        public string sCiudad { get; set; }
        public int iColonia_id { get; set; }
        public string sCalle { get; set; }
        public string sCodigoPostal { get; set; }
        public string sNombreEdificio { get; set; }
        public int iEstadoEdificio { get; set; }
        public string sUsuarioRegistraEdificio { get; set; }
        public string sFechaRegistroEdificio { get; set; }
        public string sMensaje { get; set; }
    }
    public class NivelEstructuraBean
    {
        public int iIdNivelEstructura { get; set; }
        public string sNivelEstructura { get; set; }
        public int iEstadoNivelEstructura { get; set; }
        public string sUsuarioRegistraNivel { get; set; }
        public string sFechaRegistraNivel { get; set; }
        public string sMensaje { get; set; }
    }
    public class DepartamentosBean
    {
        public int iIdDepartamento { get; set; }
        public int iCentroCosto_id { get; set; }
        public int iNivelEstructura_id { get; set; }
        public int iEdificio_id { get; set; }
        public string sDepartamento { get; set; }
        public string sDescripcionDepartamento { get; set; }
        public int iEmpresaReporta_id { get; set; }
        public string sEmpresa { get; set; }
        public string sUbicacion { get; set; }
        public string sPlaza { get; set; }
        public string sTitular { get; set; }
        public string sSucursalBancaria { get; set; }
        public string sCategoria { get; set; }
        public int iEstadoDepartamento { get; set; }
        public string sUsuarioRegistroDepartamento { get; set; }
        public string sFechaRegistroDepartamento { get; set; }
        public string sMensaje { get; set; }
    }
    public class EmpleadosBean
    {
        public int iIdEmpleado { get; set; }
        public string sNombreEmpleado { get; set; }
        public string sApellidoPaterno { get; set; }
        public string sApellidoMaterno { get; set; }
        public string sFechaNacimiento { get; set; }
        public string sLugarNacimiento { get; set; }
        public int iTitulo_id { get; set; }
        public int iGeneroEmpleado { get; set; }
        public string sNacionalidad { get; set; }
        public int iEstadoCivil { get; set; }
        public string sCodigoPostal { get; set; }
        public int iEstado_id { get; set; }
        public string sCiudad { get; set; }
        public int iColonia_id { get; set; }
        public string sCalle { get; set; }
        public string sNumeroCalle { get; set; }
        public string sTelefonoFijo { get; set; }
        public string sTelefonoMovil { get; set; }
        public string sCorreoElectronico { get; set; }
        public string sUsuarioRegistroEmpleado { get; set; }
        public string sFechaRegistroEmpleado { get; set; }
        public int iNumeroNomina { get; set; }
        public string sMensaje { get; set; }
    }
    public class ImssBean
    {
        public int iIdImss { get; set; }
        public int iEmpleado_id { get; set; }
        public string sRegistroImss { get; set; }
        public string sRfc { get; set; }
        public string sCurp { get; set; }
        public int iNivelEstudio_id { get; set; }
        public int iNivelSocioeconomico_id { get; set; }
        public int iEstadoImss { get; set; }
        public string sUsuarioRegistroImss { get; set; }
        public string sFechaRegistroImss { get; set; }
        public string sMensaje { get; set; }
    }
    public class DatosNominaBean
    {
        public int iIdNomina { get; set; }
        public int iEmpleado_id { get; set; }
        public int iNumeroNomina { get; set; }
        public double dSalarioMensual { get; set; }
        public string sPagoRetroactivo { get; set; }
        public int iTipoEmpleado_id { get; set; }
        public string sTipoMoneda { get; set; }
        public int iNivelEmpleado_id { get; set; }
        public int iTipoJornada_id { get; set; }
        public int iTipoContrato_id { get; set; }
        public string sFechaIngreso { get; set; }
        public string sFechaAntiguedad { get; set; }
        public string sVencimientoContrato { get; set; }
        public string sTipoAlta { get; set; }
        public int iEstadoNomina { get; set; }
        public string sUsuarioRegistroNomina { get; set; }
        public string sFechaRegistroNomina { get; set; }
        public string sMensaje { get; set; }
    }

    public class DatosPosicionesBean
    {
        public int iIdPosicion { get; set; }
        public int iEmpresa_id { get; set; }
        public int iPuesto_id { get; set; }
        public string sNombrePuesto { get; set; }
        public int iDepartamento_id { get; set; }
        public string sNombreDepartamento { get; set; }
        public int iPosicion { get; set; }
        public string sEmpresaReporta { get; set; }
        public string sReporta { get; set; }
        public string sTipoPago { get; set; }
        public int iBanco_id { get; set; }
        public string sCuenta { get; set; }
        public string sUsuarioRegistroPosicion { get; set; }
        public string sFechaRegistroPosicion { get; set; }
        public string sMensaje { get; set; }
    }
    public class RegionalesBean
    {
        public int iIdRegional { get; set; }
        public int iEmpresaId { get; set; }
        public string sDescripcionRegional { get; set; }
        public string sClaveRegional { get; set; }
        public int iUsuarioAltaId { get; set; }
        public string sFechaAlta { get; set; }
        public string sMensaje { get; set; }
    }

    public class SucursalesBean
    {
        public int iIdSucursal { get; set; }
        public string sDescripcionSucursal { get; set; }
        public string sClaveSucursal { get; set; }
        public int iUsuarioAltaId { get; set; }
        public string sFechaAlta { get; set; }
        public string sMensaje { get; set; }
    }
    public class ZonaEconomicaBean
    {
        public int iIdZonaEconomica { get; set; }
        public string sDescripcion {get; set; }

    }
    public class AusentismosBean
    { 
        public int iIdTipoAusentismo { get; set; }
        public string sNombreAusentismo { get; set; }
        public string sDescripcionAusentismo { get; set; }

    }
    public class DescEmpleadoVacacionesBean 
    {
        public int iFlag { get; set; }
        public int IdEmpleado { get; set; }
        public string Nombre_Empleado { get; set; }
        public string Apellido_Materno_Empleado { get; set; }
        public string Apellido_Paterno_Empleado { get; set; }
        public string DescripcionDepartamento { get; set; }
        public string DescripcionPuesto { get; set; }
        public string FechaIngreso { get; set; }
        //
        public int Id_Per_Vac { get; set; }
        public string Fecha_Aniversario { get; set; }
        public int Id_Per_Vac_Ln { get; set; }
        public int Anio { get; set; }
        public int DiasPrima { get; set; }
        public int DiasDisfrutados { get; set; }
        public int DiasRestantes { get; set; }


    }
    public class PVacacionesBean
    {
        public int iFlag { get; set; }
        public int IdEmpleado { get; set; }
        public string Nombre_Empleado { get; set; }
        public string Apellido_Materno_Empleado { get; set; }
        public string Apellido_Paterno_Empleado { get; set; }
        public string DescripcionDepartamento { get; set; }
        public string DescripcionPuesto { get; set; }
        public string FechaIngreso { get; set; }
        public int Id_Per_Vac { get; set; }
        public string FechaAntiguedad { get; set; }
        public string aniversario_proximo { get; set; }
        public string aniversario_anterior { get; set; }
        public int Id_Per_Vac_Ln { get; set; }
        public string Periodo { get; set; }
        public int DiasPrima { get; set; }
        public int DiasDisfrutados { get; set; }
        public int DiasRestantes { get; set; }


    }
    public class PeriodosVacacionesBean
    {
        public int Anio { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public int Dias { get; set; }
        public string Agendadas { get; set; }
        public string Disfrutadas { get; set; }

    }
    public class CreditosBean
    {
        public int IdCredito { get; set; }
        public int Empleado_id {get;set;}
        public int Empresa_id {get;set;}
        public string TipoDescuento {get;set;}
        public string SeguroVivienda {get;set;}
        public string Descuento {get;set;}
        public string NoCredito {get;set;}
        public string FechaAprovacionCredito {get;set;}
        public string Descontar {get;set;}
        public string FechaBaja { get; set; }
        public string FechaReinicio { get; set; }
        public string Finalizado { get; set; }
    }
    public class AusentismosEmpleadosBean
    {
        public int IdAusentismo { get; set; }
        public int Tipo_Ausentismo_id { get; set; }
        public int Empleado_id { get; set; }
        public int Empresa_id { get; set; }
        public string RecuperaAusentismo { get; set; }
        public string Fecha_Ausentismo { get; set; }
        public int Dias_Ausentismo { get; set; }
        public string Certificado_imss { get; set; }
        public string Comentarios_imss { get; set; }
        public string Causa_FaltaInjustificada { get; set; }
    }
    public class PensionesAlimentariasBean
    {
        public int IdPension { get; set; }
        public int Empleado_id { get; set; }
        public int Empresa_id { get; set; }
        public string Cuota_Fija { get; set; }
        public int Porcentaje { get; set; }
        public string AplicaEn { get; set; }
        public string Descontar_en_Finiquito { get; set; }
        public string No_Oficio { get; set; }
        public string Fecha_Oficio { get; set; }
        public string Tipo_Calculo { get; set; }
        public string Aumentar_segun_salario_minimo_general { get; set; }
        public string Aumentar_segun_aumento_de_sueldo { get; set; }
        public string Beneficiaria { get; set; }
        public int Banco { get; set; }
        public string Sucursal { get; set; }
        public string Tarjeta_vales { get; set; }
        public string Cuenta_cheques { get; set; }
        public string Fecha_baja { get; set; }
    }
}