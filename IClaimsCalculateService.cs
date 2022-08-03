using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfClaimsCalculateService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClaimsCalculateService" in both code and config file together.
    [ServiceContract]
    public interface IClaimsCalculateService
    {

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/GetInterface",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        GetInterfaceResponse GetInterface(GetInterfaceRequest interfaceRequest);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/ClaimsCalculateBatch",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ClaimsCalculateBatchResponse ClaimsCalculateBatch(ClaimsCalculateBatchRequest request);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/HCFAClaimCalculate",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        HCFAClaimDO HCFAClaimCalculate(HCFAClaimDO request);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/DentalClaimCalculate",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        DentalClaimDO DentalClaimCalculate(DentalClaimDO request);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/EncounterClaimCalculate",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        EncounterClaimDO EncounterClaimCalculate(EncounterClaimDO request);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/PharmacyClaimCalculate",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        PharmacyClaimDO PharmacyClaimCalculate(PharmacyClaimDO request);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/UBClaimCalculate",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        UBClaimDO UBClaimCalculate(UBClaimDO request);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    [DataContract]
    public class GetInterfaceRequest
    {
        [DataMember]
        public string processName { get; set; }
    }
    [DataContract]
    public class GetInterfaceResponse
    {
        [DataMember]
        public Dictionary <string, string> publicInterface { get; set; }
    }

    [DataContract]
    public class ClaimsCalculateBatchRequest
    {
        [DataMember]
        public string batchDateFrom { get; set; }

        [DataMember]
        public string batchDateTo { get; set; }

        [DataMember]
        public int batchSequenceFrom { get; set; }

        [DataMember]
        public int batchSequenceTo { get; set; }

        [DataMember]
        public string claimType { get; set; }

        [DataMember]
        public List<string> groups { get; set; }

        [DataMember]
        public LineOfBusiness lineOfBusiness { get; set;}

        [DataMember]
        public string lobCompany { get; set; }

        [DataMember]
        public int sequenceNumberFrom { get; set; }

        [DataMember]
        public int sequenceNumberTo { get; set; }

        [DataMember]
        public string serviceDateFrom { get; set; }

        [DataMember]
        public string serviceDateTo { get; set; }

        [DataMember]
        public List<string> vendors { get; set; }

        [DataMember]
        public MCOBaseRequest mcoBaseRequest { get; set; }

    }

    [DataContract]
    public class ClaimsCalculateBatchResponse
    {
        [DataMember]
        public MCOBaseResponse mcoBaseResponse { get; set; }

    }

    [DataContract]
    public class MCOBaseRequest
    {
        [DataMember]
        public UserEntity userEntity { get; set; }
    }

    [DataContract]
    public class UserEntity
    {
        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string userId { get; set; }

        [DataMember]
        public bool useSchemaReference { get; set; }
    }

    [DataContract]
    public class MCOBaseResponse
    {
        [DataMember]
        public string reasonCode { get; set; }

        [DataMember]
        public string requestId { get; set; }

        [DataMember]
        public List<ProcessError> errors { get; set; }
    }

    [DataContract]
    public class ProcessError
    {
        [DataMember]
        public string errorCode { get; set; }

        [DataMember]
        public string errorMessage { get; set; }
    }


 
    [DataContract]
    public class LineOfBusiness
    {
        [DataMember]
        public string primaryLOB { get; set; }

        [DataMember]
        public string secondaryLOB { get; set; }
    }



    [DataContract]
    public class ClaimDO
    {
        [DataMember]
        public string accidentIndicator { get; set; }

        [DataMember]
        public string adjustmentReason { get; set; }

        [DataMember]
        public string alternateClaimNumber { get; set; }

        [DataMember]
        public int approvalBatch { get; set; }

        [DataMember]
        public string approvalDate { get; set; } //DateTime

        [DataMember]
        public int approvalSequence { get; set; }

        [DataMember]
        public string auditIndicator { get; set; }

        [DataMember]
        public string batchDate { get; set; }//DateTime

        [DataMember]
        public int batchSequence { get; set; }

        [DataMember]
        public string billedCurrencyCode { get; set; }

        [DataMember]
        public string cancelFlag { get; set; }

        [DataMember]
        public string changeDate { get; set; }//DateTime

        [DataMember]
        public string changeUser { get; set; }

        [DataMember]
        public string claimCopiedFlag { get; set; }

        [DataMember]
        public string claimReportClass { get; set; }

        [DataMember]
        public string claimTypeBenefitIndicator { get; set; }

     /*   [DataMember]
        public List<ClaimDetailDO> detailOC { get; set; }*/

         [DataMember]
        public List<ClaimMessageCodeDO> messageCodeSC { get; set; }

        [DataMember]
        public string cobIndicator { get; set; }

        [DataMember]
        public float controlTotal { get; set; }

        [DataMember]
        public string copiedFromBatchDate { get; set; }//DateTime

        [DataMember]
        public int copiedFromBatchSequence { get; set; }

        [DataMember]
        public int copiedFromSequenceNumber { get; set; }

        [DataMember]
        public string dateOfInjury { get; set; }//DateTime

        [DataMember]
        public string denialIndicator { get; set; }

        [DataMember]
        public string diagnosis1 { get; set; }

        [DataMember]
        public string diagnosis2 { get; set; }

        [DataMember]
        public string diagnosis3 { get; set; }

        [DataMember]
        public string diagnosis4 { get; set; }

        [DataMember]
        public string diagnosisClass1 { get; set; }

        [DataMember]
        public string diagnosisClass2 { get; set; }

        [DataMember]
        public string diagnosisClass3 { get; set; }

        [DataMember]
        public string diagnosisClass4 { get; set; }

        [DataMember]
        public string documentControlNumber { get; set; }

        [DataMember]
        public string ediFlag { get; set; }

        [DataMember]
        public int ediFormat { get; set; }

        [DataMember]
        public int ediGeneratedCount { get; set; }

        [DataMember]
        public string ediReceiver { get; set; }

        [DataMember]
        public string ediSubmitter { get; set; }

        [DataMember]
        public string entryDate { get; set; }//DateTime

        [DataMember]
        public string entryUser { get; set; }

        [DataMember]
        public string errorInd { get; set; }

        [DataMember]
        public string evaluationStatus { get; set; }

        [DataMember]
        public string groupNumber { get; set; }

        [DataMember]
        public string hipaaIndicator { get; set; }

        [DataMember]
        public string imageID { get; set; }

        [DataMember]
        public string lastAction { get; set; }

        [DataMember]
        public string lobCompany { get; set; }

        [DataMember]
        public int mcoRTSId { get; set; }

        [DataMember]
        public string medicalEditIndicator { get; set; }

        [DataMember]
        public int memberAge { get; set; }

        [DataMember]
        public int memberReferenceKey { get; set; }

        [DataMember]
        public string memberSequence { get; set; }

        [DataMember]
        public string memberSex { get; set; }

        [DataMember]
        public string otherComments { get; set; }

        [DataMember]
        public string paidVendorLocation { get; set; }

        [DataMember]
        public string paidVendorNumber { get; set; }

        [DataMember]
        public string parentCode { get; set; }

        [DataMember]
        public string patientID { get; set; }

        [DataMember]
        public float patientPaidAmount { get; set; }

        [DataMember]
        public string paymentIndicator { get; set; }

        [DataMember]
        public string preExisting { get; set; }

        [DataMember]
        public string primaryLOB { get; set; }

        [DataMember]
        public string providerLocation { get; set; }

        [DataMember]
        public string providerNumber { get; set; }

        [DataMember]
        public string receiptDate { get; set; }//DateTime

        [DataMember]
        public string recordType { get; set; }

        [DataMember]
        public string referringPhysician { get; set; }

        [DataMember]
        public string reportedToState { get; set; }

        [DataMember]
        public string secondaryLOB { get; set; }

        [DataMember]
        public int sequenceNumber { get; set; }

        [DataMember]
        public string serviceFrom { get; set; }

        [DataMember]
        public string serviceTo { get; set; }

        [DataMember]
        public string statusCode { get; set; }

        [DataMember]
        public string subscriberNumber { get; set; }

        [DataMember]
        public int subscriberReferenceKey { get; set; }

        [DataMember]
        public string summaryDatabaseIndicator { get; set; }

        [DataMember]
        public string suppressEOBPrinting { get; set; }

        [DataMember]
        public float totalClaim { get; set; }

        [DataMember]
        public float totalCOB { get; set; }

        [DataMember]
        public float totalCOBSaved { get; set; }

        [DataMember]
        public float totalPaid { get; set; }

        [DataMember]
        public int updateTag { get; set; }

        [DataMember]
        public string vendorLocation { get; set; }

        [DataMember]
        public string vendorNumber { get; set; }

    }

    [DataContract]
    public class ProfessionalClaimDO : ClaimDO
    {
        [DataMember]
        public string admitDate { get; set; }//DateTime

        [DataMember]
        public string claimEntryType { get; set; }

        [DataMember]
        public string diagnosis10 { get; set; }

        [DataMember]
        public string diagnosis11 { get; set; }

        [DataMember]
        public string diagnosis12 { get; set; }

        [DataMember]
        public string diagnosis5 { get; set; }

        [DataMember]
        public string diagnosis6 { get; set; }

        [DataMember]
        public string diagnosis7 { get; set; }

        [DataMember]
        public string diagnosis8 { get; set; }

        [DataMember]
        public string diagnosis9 { get; set; }

        [DataMember]
        public string diagnosisQualifier { get; set; }

        [DataMember]
        public string disabilityEndDate { get; set; } //DateTime

        [DataMember]
        public string disabilityStartDate { get; set; }//DateTime

        [DataMember]
        public string dischargeDate { get; set; }//DateTime

        [DataMember]
        public string ediMemberDOB { get; set; }//DateTime

        [DataMember]
        public string hasOutsideLabworkCode { get; set; }

        [DataMember]
        public string onsetDate { get; set; }//DateTime

        [DataMember]
        public string originalReferenceNumber { get; set; }

        [DataMember]
        public float outsideLabCharges { get; set; }

        [DataMember]
        public string priorAuthorizationNumber { get; set; }

        [DataMember]
        public string providerAcceptingAssignmentsCode { get; set; }

        [DataMember]
        public string referringPhysicianFirstName { get; set; }

        [DataMember]
        public string referringPhysicianId { get; set; }

        [DataMember]
        public string referringPhysicianLastName { get; set; }

        [DataMember]
        public string referringPhysicianMiddleInitial { get; set; }

        [DataMember]
        public string resubmissionReasonCode { get; set; }

        [DataMember]
        public string secondaryReceiptDate { get; set; }//DateTime

    }

    [DataContract]
    public class DentalClaimDO : ProfessionalClaimDO
    {
        [DataMember]
        public List<DentalDetailDO> detailOC { get; set; }

    }

    [DataContract]
    public class EncounterClaimDO : ProfessionalClaimDO
    {
        [DataMember]
        public List<EncounterDetailDO> detailOC { get; set; }

    }

    [DataContract]
    public class HCFAClaimDO : ProfessionalClaimDO
    {
        [DataMember]
        public List<HCFADetailDO> detailOC { get; set; }

    }

    [DataContract]
    public class PharmacyClaimDO : ProfessionalClaimDO
    {
        [DataMember]
        public new string claimEntryType { get; set; }

        [DataMember]
        public new string diagnosis5 { get; set; }

        [DataMember]
        public new string diagnosis6 { get; set; }

        [DataMember]
        public new string diagnosis7 { get; set; }

        [DataMember]
        public new string diagnosis8 { get; set; }

        [DataMember]
        public new string diagnosis9 { get; set; }

        [DataMember]
        public new string diagnosisQualifier { get; set; }

        [DataMember]
        public string nonMcoPhysicianIdType { get; set; }

        [DataMember]
        public string nonMcoPhysicianIdValue { get; set; }

        [DataMember]
        public new string originalReferenceNumber { get; set; }

        [DataMember]
        public string prescribingPhysicianFirstName { get; set; }

        [DataMember]
        public string prescribingPhysicianId { get; set; }

        [DataMember]
        public string prescribingPhysicianLastName { get; set; }

        [DataMember]
        public string prescribingPhysicianMiddleInitia { get; set; }

        [DataMember]
        public string prescriptionOriginCode { get; set; }

        [DataMember]
        public new string priorAuthorizationNumber { get; set; }

        [DataMember]
        public List<PharmacyDetailDO> detailOC { get; set; }

    }

    [DataContract]
    public class UBClaimDO : ClaimDO
    {
        [DataMember]
        public string accidentState { get; set; }

        [DataMember]
        public string admitDate { get; set; }//DateTime

        [DataMember]
        public string admitDiagnosisCode { get; set; }

        [DataMember]
        public string admitHour { get; set; }

        [DataMember]
        public string admitSource { get; set; }

        [DataMember]
        public string admitType { get; set; }

        [DataMember]
        public string billType1 { get; set; }

        [DataMember]
        public string billType2 { get; set; }

        [DataMember]
        public string billType3 { get; set; }

        [DataMember]
        public string billType4 { get; set; }

        [DataMember]
        public List<UBDetailDO> detailOC { get; set; }

        [DataMember]
        public new string lastAction { get; set; }

        [DataMember]
        public float coInsuranceDays { get; set; }

        [DataMember]
        public float coveredDays { get; set; }

        [DataMember]
        public string diagnosis10 { get; set; }

        [DataMember]
        public string diagnosis10POA { get; set; }

        [DataMember]
        public string diagnosis11 { get; set; }

        [DataMember]
        public string diagnosis11POA { get; set; }

        [DataMember]
        public string diagnosis12 { get; set; }

        [DataMember]
        public string diagnosis12POA { get; set; }

        [DataMember]
        public string diagnosis13 { get; set; }

        [DataMember]
        public string diagnosis13POA { get; set; }

        [DataMember]
        public string diagnosis14 { get; set; }

        [DataMember]
        public string diagnosis14POA { get; set; }

        [DataMember]
        public string diagnosis15 { get; set; }

        [DataMember]
        public string diagnosis15POA { get; set; }

        [DataMember]
        public string diagnosis16 { get; set; }

        [DataMember]
        public string diagnosis16POA { get; set; }

        [DataMember]
        public string diagnosis17 { get; set; }

        [DataMember]
        public string diagnosis17POA { get; set; }

        [DataMember]
        public string diagnosis18 { get; set; }

        [DataMember]
        public string diagnosis18POA { get; set; }

        [DataMember]
        public string diagnosis19 { get; set; }

        [DataMember]
        public string diagnosis19POA { get; set; }

        [DataMember]
        public string diagnosis1POA { get; set; }

        [DataMember]
        public string diagnosis20 { get; set; }

        [DataMember]
        public string diagnosis20POA { get; set; }

        [DataMember]
        public string diagnosis21 { get; set; }

        [DataMember]
        public string diagnosis21POA { get; set; }

        [DataMember]
        public string diagnosis22 { get; set; }

        [DataMember]
        public string diagnosis22POA { get; set; }

        [DataMember]
        public string diagnosis23 { get; set; }

        [DataMember]
        public string diagnosis23POA { get; set; }

        [DataMember]
        public string diagnosis24 { get; set; }

        [DataMember]
        public string diagnosis24POA { get; set; }

        [DataMember]
        public string diagnosis25 { get; set; }

        [DataMember]
        public string diagnosis25POA { get; set; }

        [DataMember]
        public string diagnosis2POA { get; set; }

        [DataMember]
        public string diagnosis3POA { get; set; }

        [DataMember]
        public string diagnosis4POA { get; set; }

        [DataMember]
        public string diagnosis5 { get; set; }

        [DataMember]
        public string diagnosis5POA { get; set; }

        [DataMember]
        public string diagnosis6 { get; set; }

        [DataMember]
        public string diagnosis6POA { get; set; }

        [DataMember]
        public string diagnosis7 { get; set; }

        [DataMember]
        public string diagnosis7POA { get; set; }

        [DataMember]
        public string diagnosis8 { get; set; }

        [DataMember]
        public string diagnosis8POA { get; set; }

        [DataMember]
        public string diagnosis9 { get; set; }

        [DataMember]
        public string diagnosis9POA { get; set; }

        [DataMember]
        public string diagnosisClass10 { get; set; }

        [DataMember]
        public string diagnosisClass11 { get; set; }

        [DataMember]
        public string diagnosisClass12 { get; set; }

        [DataMember]
        public string diagnosisClass13 { get; set; }

        [DataMember]
        public string diagnosisClass14 { get; set; }

        [DataMember]
        public string diagnosisClass15 { get; set; }

        [DataMember]
        public string diagnosisClass16 { get; set; }

        [DataMember]
        public string diagnosisClass17 { get; set; }

        [DataMember]
        public string diagnosisClass18 { get; set; }

        [DataMember]
        public string diagnosisClass19 { get; set; }

        [DataMember]
        public string diagnosisClass20 { get; set; }

        [DataMember]
        public string diagnosisClass21 { get; set; }

        [DataMember]
        public string diagnosisClass22 { get; set; }

        [DataMember]
        public string diagnosisClass23 { get; set; }

        [DataMember]
        public string diagnosisClass24 { get; set; }

        [DataMember]
        public string diagnosisClass25 { get; set; }

        [DataMember]
        public string diagnosisClass5 { get; set; }

        [DataMember]
        public string diagnosisClass6 { get; set; }

        [DataMember]
        public string diagnosisClass7 { get; set; }

        [DataMember]
        public string diagnosisClass8 { get; set; }

        [DataMember]
        public string diagnosisClass9 { get; set; }

        [DataMember]
        public string diagnosisQualifier { get; set; }

        [DataMember]
        public string dischargeDate { get; set; }//DateTime

        [DataMember]
        public string dischargeHour { get; set; }

        [DataMember]
        public string drgCode { get; set; }

        [DataMember]
        public string eCode { get; set; }

        [DataMember]
        public string eCode2 { get; set; }

        [DataMember]
        public string eCode3 { get; set; }

        [DataMember]
        public string ediMemberDOB { get; set; }//DateTime

        [DataMember]
        public float estimatedAmountDuePatient { get; set; }

        [DataMember]
        public float lifetimeReserveDays { get; set; }

        [DataMember]
        public string medicalRecordNumber { get; set; }

        [DataMember]
        public float nonCoveredDays { get; set; }

        [DataMember]
        public string partialBill { get; set; }

        [DataMember]
        public float patientPriorPayment { get; set; }

        [DataMember]
        public string patientReasonDiag1 { get; set; }

        [DataMember]
        public string patientReasonDiag2 { get; set; }

        [DataMember]
        public string patientReasonDiag3 { get; set; }

        [DataMember]
        public string patientStatusCode { get; set; }

        [DataMember]
        public string placeOfService { get; set; }

        [DataMember]
        public string preExistingTableCode { get; set; }

        [DataMember]
        public string procedureCodingMethod { get; set; }

        [DataMember]
        public string reimbursementGenerationPackageCo { get; set; }

        [DataMember]
        public string secondaryReceiptDate { get; set; }//DateTime

        [DataMember]
        public string serviceCode1 { get; set; }

        [DataMember]
        public string serviceCode10 { get; set; }

        [DataMember]
        public string serviceCode11 { get; set; }

        [DataMember]
        public string serviceCode12 { get; set; }

        [DataMember]
        public string serviceCode13 { get; set; }

        [DataMember]
        public string serviceCode14 { get; set; }

        [DataMember]
        public string serviceCode15 { get; set; }

        [DataMember]
        public string serviceCode16 { get; set; }

        [DataMember]
        public string serviceCode17 { get; set; }

        [DataMember]
        public string serviceCode18 { get; set; }

        [DataMember]
        public string serviceCode19 { get; set; }

        [DataMember]
        public string serviceCode2 { get; set; }

        [DataMember]
        public string serviceCode20 { get; set; }

        [DataMember]
        public string serviceCode21 { get; set; }

        [DataMember]
        public string serviceCode22 { get; set; }

        [DataMember]
        public string serviceCode23 { get; set; }

        [DataMember]
        public string serviceCode24 { get; set; }

        [DataMember]
        public string serviceCode25 { get; set; }

        [DataMember]
        public string serviceCode3 { get; set; }

        [DataMember]
        public string serviceCode4 { get; set; }

        [DataMember]
        public string serviceCode5 { get; set; }

        [DataMember]
        public string serviceCode6 { get; set; }

        [DataMember]
        public string serviceCode7 { get; set; }

        [DataMember]
        public string serviceCode8 { get; set; }

        [DataMember]
        public string serviceCode9 { get; set; }

        [DataMember]
        public string serviceDate1 { get; set; }//DateTime

        [DataMember]
        public string serviceDate10 { get; set; }//DateTime

        [DataMember]
        public string serviceDate11 { get; set; }//DateTime

        [DataMember]
        public string serviceDate12 { get; set; }//DateTime

        [DataMember]
        public string serviceDate13 { get; set; }//DateTime

        [DataMember]
        public string serviceDate14 { get; set; }//DateTime

        [DataMember]
        public string serviceDate15 { get; set; }//DateTime

        [DataMember]
        public string serviceDate16 { get; set; }//DateTime

        [DataMember]
        public string serviceDate17 { get; set; }//DateTime

        [DataMember]
        public string serviceDate18 { get; set; }//DateTime

        [DataMember]
        public string serviceDate19 { get; set; }//DateTime

        [DataMember]
        public string serviceDate2 { get; set; }//DateTime

        [DataMember]
        public string serviceDate20 { get; set; }//DateTime

        [DataMember]
        public string serviceDate21 { get; set; }//DateTime

        [DataMember]
        public string serviceDate22 { get; set; }//DateTime

        [DataMember]
        public string serviceDate23 { get; set; }//DateTime

        [DataMember]
        public string serviceDate24 { get; set; }//DateTime

        [DataMember]
        public string serviceDate25 { get; set; }//DateTime

        [DataMember]
        public string serviceDate3 { get; set; }//DateTime

        [DataMember]
        public string serviceDate4 { get; set; }//DateTime

        [DataMember]
        public string serviceDate5 { get; set; }//DateTime

        [DataMember]
        public string serviceDate6 { get; set; }//DateTime

        [DataMember]
        public string serviceDate7 { get; set; }//DateTime

        [DataMember]
        public string serviceDate8 { get; set; }//DateTime

        [DataMember]
        public string serviceDate9 { get; set; }//DateTime

        [DataMember]
        public string subrogationCode { get; set; }

    }

    [DataContract]
    public class ClaimMessageCodeDO
    {
        [DataMember]
        public string batchDate { get; set; }//DateTime

        [DataMember]
        public int batchSequence { get; set; }

        [DataMember]
        public string defaultEOPMessage { get; set; }

        [DataMember]
        public string denialFlag { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string descriptionWasModified { get; set; }

        [DataMember]
        public string entryDate { get; set; }//DateTime

        [DataMember]
        public string entryUser { get; set; }

        [DataMember]
        public string manualDelete { get; set; }

        [DataMember]
        public string messageCode { get; set; }

        [DataMember]
        public string messageLevel { get; set; }

        [DataMember]
        public string modifyDescription { get; set; }

        [DataMember]
        public string secondaryType { get; set; }

        [DataMember]
        public string statusCode { get; set; }

        [DataMember]
        public string eopCode { get; set; }

        [DataMember]
        public string excludeFromEOB { get; set; }

        [DataMember]
        public string letterSet { get; set; }

        [DataMember]
        public string lineNumber { get; set; }

        [DataMember]
        public string messageSource { get; set; }

        [DataMember]
        public string postedIndicator { get; set; }

        [DataMember]
        public int sequenceNumber { get; set; }

        [DataMember]
        public string systemEdit { get; set; }

        [DataMember]
        public int uniqueSequence { get; set; }

    }


    [DataContract]
    public class ClaimDetailDO
    {
        [DataMember]
        public string adjudicationDateFromTimestamp { get; set; }//DateTime

        [DataMember]
        public string adjudicationUser { get; set; }

        [DataMember]
        public decimal allowedAmount { get; set; }

        [DataMember]
        public float allowedUnits { get; set; }

        [DataMember]
        public string approvalDetail { get; set; }

        [DataMember]
        public string approvalIndicator { get; set; }

        [DataMember]
        public string approvalType { get; set; }

        [DataMember]
        public string aptBatchDate { get; set; }//DateTime

        [DataMember]
        public int aptBatchSequence { get; set; }

        [DataMember]
        public int aptSequence { get; set; }

        [DataMember]
        public List<ClaimCOBDetailDO> cobDetailOC { get; set; }

        [DataMember]
        public string auditorGeneratedIndicator { get; set; }

        [DataMember]
        public string authorizedUnits { get; set; }

        [DataMember]
        public string batchDate { get; set; }//DateTime

        [DataMember]
        public int batchSequence { get; set; }

        [DataMember]
        public string benefitCode { get; set; }

        [DataMember]
        public string benefitPackage { get; set; }

        [DataMember]
        public float billedCurrencyFactor { get; set; }

        [DataMember]
        public string changeDate { get; set; }//DateTime

        [DataMember]
        public string changeUser { get; set; }

        [DataMember]
        public float chargedAmount { get; set; }

        [DataMember]
        public float chargedUnits { get; set; }

        [DataMember]
        public int checkNumber { get; set; }

        [DataMember]
        public string checkRunDate { get; set; }//DateTime

        [DataMember]
        public string claimDistribPackageTwo { get; set; }

        [DataMember]
        public string claimDistribTwoName { get; set; }

        [DataMember]
        public string cmsInterestFlag { get; set; }

        [DataMember]
        public float cobAmount { get; set; }

        [DataMember]
        public float cobSavedAmount { get; set; }

        [DataMember]
        public float coInsuranceAmount { get; set; }

        [DataMember]
        public string contractNumber { get; set; }

        [DataMember]
        public float convertedChargedAmount { get; set; }

        [DataMember]
        public float copayAmount { get; set; }

        [DataMember]
        public string copiedDetailFlag { get; set; }

        [DataMember]
        public string countyCode { get; set; }

        [DataMember]
        public int daysReducedViaMessageCode { get; set; }

        [DataMember]
        public int daysTakenToProcess { get; set; }

        [DataMember]
        public float deductibleAmount { get; set; }

        [DataMember]
        public string denialIndicator { get; set; }

        [DataMember]
        public float disallowedAmount { get; set; }

        [DataMember]
        public float discountAmount { get; set; }

        [DataMember]
        public float discountPercent { get; set; }

        [DataMember]
        public string ediFlag { get; set; }

        [DataMember]
        public string ediReceiver { get; set; }

        [DataMember]
        public string endingDate { get; set; }//DateTime

        [DataMember]
        public string enrolledAssociation { get; set; }

        [DataMember]
        public string entryDate { get; set; }//DateTime

        [DataMember]
        public string entryUser { get; set; }

        [DataMember]
        public string eopFormCode { get; set; }

        [DataMember]
        public string errorInd { get; set; }

        [DataMember]
        public string feeScheduleTable { get; set; }

        [DataMember]
        public string feeType { get; set; }

        [DataMember]
        public string financialAccountCode { get; set; }

        [DataMember]
        public string fourthModifier { get; set; }

        [DataMember]
        public string groupLocationCode { get; set; }

        [DataMember]
        public string inAssocOutAssocFlag { get; set; }

        [DataMember]
        public string inpatOutpatFlag { get; set; }

        [DataMember]
        public string inplanOutplanFlag { get; set; }

        [DataMember]
        public string lastAction { get; set; }

        [DataMember]
        public string liabilityPackageCode { get; set; }

        [DataMember]
        public int lineNumber { get; set; }

        [DataMember]
        public string lobCompany { get; set; }

        [DataMember]
        public string manualProcessed { get; set; }

        [DataMember]
        public string mcoCode { get; set; }

        [DataMember]
        public int memberContractPointer { get; set; }

        [DataMember]
        public string memberPoolFundIndicator { get; set; }

        [DataMember]
        public string memberStatus { get; set; }

        [DataMember]
        public float nonAuthorizedAmount { get; set; }

        [DataMember]
        public float nonCoveredAmount { get; set; }

        [DataMember]
        public int numberOfDays { get; set; }

        [DataMember]
        public float oopAmount { get; set; }

        [DataMember]
        public float paidAmount { get; set; }

        [DataMember]
        public string paidDate { get; set; }//DateTime

        [DataMember]
        public string parNonParFlag { get; set; }

        [DataMember]
        public string paymentBatchDate { get; set; }//DateTime

        [DataMember]
        public int paymentBatchSequence { get; set; }

        [DataMember]
        public int paymentBatchSequenceNumber { get; set; }

        [DataMember]
        public string paymentProcessingBatchDate { get; set; }//DateTime

        [DataMember]
        public int paymentProcessingBatchSequence { get; set; }

        [DataMember]
        public string pcpSpecialistFlag { get; set; }

        [DataMember]
        public float penaltyAmount { get; set; }

        [DataMember]
        public string poolFundPackage { get; set; }

        [DataMember]
        public string poolName { get; set; }

        [DataMember]
        public string postedDate { get; set; }//DateTime

        [DataMember]
        public float prepaidAmount { get; set; }

        [DataMember]
        public string primaryCarePhysician { get; set; }

        [DataMember]
        public string primaryLOB { get; set; }

        [DataMember]
        public string primaryModifier { get; set; }

        [DataMember]
        public string processedCurrencyCode { get; set; }

        [DataMember]
        public float processedCurrencyFactor { get; set; }

        [DataMember]
        public string providerAssociationCode { get; set; }

        [DataMember]
        public int providerContractId { get; set; }

        [DataMember]
        public string providerLineNumber { get; set; }

        [DataMember]
        public int replacedBy { get; set; }

        [DataMember]
        public string reversalFlag { get; set; }

        [DataMember]
        public int reversedFrom { get; set; }

        [DataMember]
        public int reversedTo { get; set; }

        [DataMember]
        public string secondaryLOB { get; set; }

        [DataMember]
        public string secondaryModifier { get; set; }

        [DataMember]
        public int sequenceNumber { get; set; }

        [DataMember]
        public string serviceClass { get; set; }

        [DataMember]
        public string serviceCode { get; set; }

        [DataMember]
        public string serviceDate { get; set; }//DateTime

        [DataMember]
        public string specialtyClass { get; set; }

        [DataMember]
        public string specialtyType { get; set; }

        [DataMember]
        public string statusCode { get; set; }

        [DataMember]
        public int stepFromLine { get; set; }

        [DataMember]
        public string summaryDatabaseIndicator { get; set; }

        [DataMember]
        public string summaryDatabaseIndicatorCustom { get; set; }

        [DataMember]
        public string summaryDBIndicatorTwo { get; set; }

        [DataMember]
        public float taxationAmount { get; set; }

        [DataMember]
        public string tertiaryModifier { get; set; }

        [DataMember]
        public string tierCode { get; set; }

        [DataMember]
        public int updateTag { get; set; }

        [DataMember]
        public float withholdAmount { get; set; }

        [DataMember]
        public float withholdPercent { get; set; }

    }

    [DataContract]
    public class ProfessionalClaimDetailDO : ClaimDetailDO
    {
        [DataMember]
        public string cobIndicator { get; set; }

        [DataMember]
        public string diagnosis1 { get; set; }

        [DataMember]
        public string diagnosis2 { get; set; }

        [DataMember]
        public string diagnosis3 { get; set; }

        [DataMember]
        public string diagnosis4 { get; set; }

        [DataMember]
        public string diagnosisClass1 { get; set; }

        [DataMember]
        public string diagnosisClass2 { get; set; }

        [DataMember]
        public string diagnosisClass3 { get; set; }

        [DataMember]
        public string diagnosisClass4 { get; set; }

        [DataMember]
        public string emgIndicator { get; set; }

        [DataMember]
        public string epsIndicator { get; set; }

        [DataMember]
        public string invalidDiagnosisEntry { get; set; }

        [DataMember]
        public int numberOfMinutes { get; set; }

        [DataMember]
        public string placeOfService { get; set; }

        [DataMember]
        public string preExistingTableCode { get; set; }

        [DataMember]
        public string subrogationCode { get; set; }

        [DataMember]
        public string toothNumber { get; set; }

        [DataMember]
        public string toothSurface { get; set; }

        [DataMember]
        public string typeOfService { get; set; }

    }

    [DataContract]
    public class DentalDetailDO : ProfessionalClaimDetailDO
    {
        [DataMember]
        public int claimCheckAccountId { get; set; }

    }

    [DataContract]
    public class EncounterDetailDO : ProfessionalClaimDetailDO
    {
        [DataMember]
        public int claimCheckAccountId { get; set; }


    }

    [DataContract]
    public class HCFADetailDO : ProfessionalClaimDetailDO
    {
        [DataMember]
        public int claimCheckAccountId { get; set; }

        [DataMember]
        public int claimCheckAllowedUnits { get; set; }


    }

    [DataContract]
    public class HCFAGeneratedDetailDO : HCFADetailDO
    {
    }

    [DataContract]
    public class HCFAClaimCheckGeneratedDetailDO : HCFAGeneratedDetailDO
    {
    }

    [DataContract]
    public class HCFAStepdownDetailDO : HCFAGeneratedDetailDO
    {
    }

    [DataContract]
    public class PharmacyDetailDO : ProfessionalClaimDetailDO
    {
        [DataMember]
        public new string cobIndicator { get; set; }

        [DataMember]
        public string compoundCode { get; set; }

        [DataMember]
        public float creditAmount { get; set; }

        [DataMember]
        public string dateOrdered { get; set; }//DateTime

        [DataMember]
        public new string diagnosis1 { get; set; }

        [DataMember]
        public new string diagnosis2 { get; set; }

        [DataMember]
        public new string diagnosis3 { get; set; }

        [DataMember]
        public new string diagnosis4 { get; set; }

        [DataMember]
        public new string diagnosisClass1 { get; set; }

        [DataMember]
        public new string diagnosisClass2 { get; set; }

        [DataMember]
        public new string diagnosisClass3 { get; set; }

        [DataMember]
        public new string diagnosisClass4 { get; set; }

        [DataMember]
        public string dispensedAsWritten { get; set; }

        [DataMember]
        public float dispensingFee { get; set; }

        [DataMember]
        public float dispensingFeeSubmitted { get; set; }

        [DataMember]
        public string dispensingStatus { get; set; }

        [DataMember]
        public int drugDaysSupply { get; set; }

        [DataMember]
        public string durIntervention { get; set; }

        [DataMember]
        public string durOutcome { get; set; }

        [DataMember]
        public string durReason { get; set; }

        [DataMember]
        public string exportedToCMS { get; set; }

        [DataMember]
        public int fillNumber { get; set; }

        [DataMember]
        public float incentiveAmountPaid { get; set; }

        [DataMember]
        public float incentiveAmountSubmitted { get; set; }

        [DataMember]
        public int levelOfService { get; set; }

        [DataMember]
        public string mailOrderPharmacyIndicator { get; set; }

        [DataMember]
        public int memberPDEExceptionID { get; set; }

        [DataMember]
        public string ndcCode { get; set; }

        [DataMember]
        public int numberOfRefillsAuthorized { get; set; }

        [DataMember]
        public float otherAmountClaimedPaid { get; set; }

        [DataMember]
        public float otherAmountClaimedSubmitted { get; set; }

        [DataMember]
        public float patientPaidAmountSubmitted { get; set; }

        [DataMember]
        public float percentageSalesTaxPaid { get; set; }

        [DataMember]
        public float percentageSalesTaxSubmitted { get; set; }

        [DataMember]
        public new string placeOfService { get; set; }

        [DataMember]
        public new string preExistingTableCode { get; set; }

        [DataMember]
        public string prescriptionReferenceNumber { get; set; }

        [DataMember]
        public string prescriptionSerialNumber { get; set; }

        [DataMember]
        public string refillIndicator { get; set; }

        [DataMember]
        public float salesTax { get; set; }

        [DataMember]
        public float salesTaxSubmitted { get; set; }

        [DataMember]
        public string submissionClassificationCode { get; set; }

        [DataMember]
        public new string subrogationCode { get; set; }

        [DataMember]
        public new string typeOfService { get; set; }

    }

    [DataContract]
    public class UBDetailDO : ClaimDetailDO
    {
        [DataMember]
        public string caseRatePackage { get; set; }

        [DataMember]
        public int claimCheckAccountId { get; set; }

        [DataMember]
        public int claimCheckAllowedUnits { get; set; }

        [DataMember]
        public float convertedNonCoveredCharges { get; set; }

        [DataMember]
        public int generatedFromLine { get; set; }

        [DataMember]
        public float nonCoveredCharges { get; set; }

        [DataMember]
        public string pricedViaAPCServiceCodeExclusion { get; set; }

        [DataMember]
        public string pricedViaCaseRate { get; set; }

        [DataMember]
        public string pricedViaCaseRateCarveOut { get; set; }

        [DataMember]
        public string pricerFlag { get; set; }

        [DataMember]
        public string revenueCode { get; set; }

        [DataMember]
        public string serviceType { get; set; }

        [DataMember]
        public string ubGeneratedLineFlag { get; set; }

    }

    [DataContract]
    public class UBGeneratedDetailDO : UBDetailDO
    {
    }

    [DataContract]
    public class UBClaimCheckGeneratedDetailDO : UBGeneratedDetailDO
    {
    }

    [DataContract]
    public class UBDRGGeneratedDetailDO : UBGeneratedDetailDO
    {
    }

    [DataContract]
    public class UBDRGStepdownDetailDO : UBDRGGeneratedDetailDO
    {
    }

    [DataContract]
    public class UBReimbursementGeneratedDetailDO : UBGeneratedDetailDO
    {
    }

    [DataContract]
    public class UBReimbursementStepdownDetailDO : UBReimbursementGeneratedDetailDO
    {
    }

    [DataContract]
    public class UBStepdownDetailDO : UBGeneratedDetailDO
    {
    }

    [DataContract]
    public class UBStopLossGeneratedDetailDO : UBGeneratedDetailDO
    {
    }

    [DataContract]
    public class ClaimCOBDetailDO
    {
        [DataMember]
        public string amountOwed { get; set; }

        [DataMember]
        public string batchDate { get; set; }//DateTime

        [DataMember]
        public int batchSequence { get; set; }

        [DataMember]
        public string claimPayerAllowedAmount { get; set; }

        [DataMember]
        public string claimType { get; set; }

        [DataMember]
        public string coInsuranceAmount { get; set; }

        [DataMember]
        public string copayAmount { get; set; }

        [DataMember]
        public string deductibleAmount { get; set; }

        [DataMember]
        public string insuredAllowedAmount { get; set; }

        [DataMember]
        public string insuredPaidAmount { get; set; }

        [DataMember]
        public int lineNumber { get; set; }

        [DataMember]
        public string memberPaidAmount { get; set; }

        [DataMember]
        public string payerAllowedAmount { get; set; }

        [DataMember]
        public string payerPaidAmount { get; set; }

        [DataMember]
        public int sequenceNumber { get; set; }

        [DataMember]
        public string totalCoinsuranceAmount { get; set; }

        [DataMember]
        public string totalCopayAmount { get; set; }

        [DataMember]
        public string totalDeductibleAmount { get; set; }

        [DataMember]
        public string totalPaidAmount { get; set; }


    }

}
