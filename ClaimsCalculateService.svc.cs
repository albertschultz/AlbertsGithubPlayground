using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Reflection;
using System.Collections;

namespace WcfClaimsCalculateService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClaimsCalculateService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClaimsCalculateService.svc or ClaimsCalculateService.svc.cs at the Solution Explorer and start debugging.
    public class ClaimsCalculateService : IClaimsCalculateService
    {

        public GetInterfaceResponse GetInterface(GetInterfaceRequest interfaceRequest)
        {
            Dictionary<string, string> interfaceDictionary = new Dictionary<string,string>();
            GetInterfaceResponse interfaceResponse = new GetInterfaceResponse();
            interfaceResponse.publicInterface = interfaceDictionary;

            if (interfaceRequest == null)
            {
                return null;
            }

            if (interfaceRequest.processName == null)
            {
                return null;
            }

            if ( interfaceRequest.processName == "Calculation")
            {
                interfaceDictionary.Add("ClaimsCalculateBatchRequest", "ClaimsCalculateBatch");
                interfaceDictionary.Add("HCFAClaimDO", "HCFAClaimCalculate");
                interfaceDictionary.Add("DentalClaimDO", "DentalClaimCalculate");
                interfaceDictionary.Add("EncounterClaimDO", "EncounterClaimCalculate");
                interfaceDictionary.Add("PharmacyClaimDO", "PharmacyClaimCalculate");
                interfaceDictionary.Add("UBClaimDO", "UBClaimCalculate");
            }

            return interfaceResponse;
        }
        public ClaimsCalculateBatchResponse ClaimsCalculateBatch(ClaimsCalculateBatchRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("ClaimsCalculateBatchRequest");
            }
            
            return processBatchRequest(request);
        }

        public ClaimsCalculateBatchResponse processBatchRequest(ClaimsCalculateBatchRequest request)
        {
            ClaimsCalculateBatchResponse response = new ClaimsCalculateBatchResponse();
            
            return populateBatchResponse(response, request);
        }

        public ClaimsCalculateBatchResponse populateBatchResponse(ClaimsCalculateBatchResponse response, ClaimsCalculateBatchRequest request)
        {
            MCOBaseResponse mcoBaseResponse = new MCOBaseResponse();
            mcoBaseResponse.requestId = "12345";
            mcoBaseResponse.errors = new List<ProcessError>();
            mcoBaseResponse.reasonCode = "";
            response.mcoBaseResponse = mcoBaseResponse;

            return response;
        }

        public HCFAClaimDO HCFAClaimCalculate(HCFAClaimDO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("ClaimCalculateRequest");
            }

            return processClaimCalculateRequest(request);
        }

        public HCFAClaimDO processClaimCalculateRequest(HCFAClaimDO request)
        {

            return populateClaimCalculateResponse(request);
        }

        public HCFAClaimDO populateClaimCalculateResponse(HCFAClaimDO request)
        {
         
           
            foreach (HCFADetailDO detailDO in request.detailOC)
            {
                if ( detailDO.allowedAmount  > 0)
                    detailDO.allowedAmount = detailDO.allowedAmount - 1;
                if (detailDO.chargedAmount > 0)
                    detailDO.chargedAmount = detailDO.chargedAmount - 1;
                if (detailDO.cobAmount > 0)
                    detailDO.cobAmount = detailDO.cobAmount - 1;
                if (detailDO.cobSavedAmount > 0)
                    detailDO.cobSavedAmount = detailDO.cobSavedAmount - 1;
                if (detailDO.convertedChargedAmount > 0)
                    detailDO.convertedChargedAmount = detailDO.convertedChargedAmount - 1;
                if (detailDO.disallowedAmount > 0)
                    detailDO.disallowedAmount = detailDO.disallowedAmount + 1;
                detailDO.lastAction = "C";
                detailDO.statusCode = "C";
             }
            request.messageCodeSC = request.messageCodeSC;
            request.lastAction = "C";
            request.statusCode = "C";
            request.totalClaim = request.totalClaim - 1;
            request.totalPaid = request.totalPaid - 1;

            return request;
        }

        public DentalClaimDO DentalClaimCalculate(DentalClaimDO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("ClaimCalculateRequest");
            }

            return processClaimCalculateRequest(request);
        }

        public DentalClaimDO processClaimCalculateRequest(DentalClaimDO request)
        {

            return populateClaimCalculateResponse(request);
        }

        public DentalClaimDO populateClaimCalculateResponse(DentalClaimDO request)
        {


            foreach (DentalDetailDO detailDO in request.detailOC)
            {
                if (detailDO.allowedAmount > 0)
                    detailDO.allowedAmount = detailDO.allowedAmount - 1;
                if (detailDO.chargedAmount > 0)
                    detailDO.chargedAmount = detailDO.chargedAmount - 1;
                if (detailDO.cobAmount > 0)
                    detailDO.cobAmount = detailDO.cobAmount - 1;
                if (detailDO.cobSavedAmount > 0)
                    detailDO.cobSavedAmount = detailDO.cobSavedAmount - 1;
                if (detailDO.convertedChargedAmount > 0)
                    detailDO.convertedChargedAmount = detailDO.convertedChargedAmount - 1;
                if (detailDO.disallowedAmount > 0)
                    detailDO.disallowedAmount = detailDO.disallowedAmount + 1;
                detailDO.lastAction = "C";
                detailDO.statusCode = "C";
            }
            request.messageCodeSC = request.messageCodeSC;
            request.lastAction = "C";
            request.statusCode = "C";
            request.totalClaim = request.totalClaim - 1;
            request.totalPaid = request.totalPaid - 1;

            return request;
        }

        public EncounterClaimDO EncounterClaimCalculate(EncounterClaimDO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("ClaimCalculateRequest");
            }

            return processClaimCalculateRequest(request);
        }

        public EncounterClaimDO processClaimCalculateRequest(EncounterClaimDO request)
        {

            return populateClaimCalculateResponse(request);
        }

        public EncounterClaimDO populateClaimCalculateResponse(EncounterClaimDO request)
        {


            foreach (EncounterDetailDO detailDO in request.detailOC)
            {
                if (detailDO.allowedAmount > 0)
                    detailDO.allowedAmount = detailDO.allowedAmount - 1;
                if (detailDO.chargedAmount > 0)
                    detailDO.chargedAmount = detailDO.chargedAmount - 1;
                if (detailDO.cobAmount > 0)
                    detailDO.cobAmount = detailDO.cobAmount - 1;
                if (detailDO.cobSavedAmount > 0)
                    detailDO.cobSavedAmount = detailDO.cobSavedAmount - 1;
                if (detailDO.convertedChargedAmount > 0)
                    detailDO.convertedChargedAmount = detailDO.convertedChargedAmount - 1;
                if (detailDO.disallowedAmount > 0)
                    detailDO.disallowedAmount = detailDO.disallowedAmount + 1;
                detailDO.lastAction = "C";
                detailDO.statusCode = "C";
            }
            request.messageCodeSC = request.messageCodeSC;
            request.lastAction = "C";
            request.statusCode = "C";
            request.totalClaim = request.totalClaim - 1;
            request.totalPaid = request.totalPaid - 1;

            return request;
        }

        public PharmacyClaimDO PharmacyClaimCalculate(PharmacyClaimDO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("ClaimCalculateRequest");
            }

            return processClaimCalculateRequest(request);
        }

        public PharmacyClaimDO processClaimCalculateRequest(PharmacyClaimDO request)
        {

            return populateClaimCalculateResponse(request);
        }

        public PharmacyClaimDO populateClaimCalculateResponse(PharmacyClaimDO request)
        {


            foreach (PharmacyDetailDO detailDO in request.detailOC)
            {
                if (detailDO.allowedAmount > 0)
                    detailDO.allowedAmount = detailDO.allowedAmount - 1;
                if (detailDO.chargedAmount > 0)
                    detailDO.chargedAmount = detailDO.chargedAmount - 1;
                if (detailDO.cobAmount > 0)
                    detailDO.cobAmount = detailDO.cobAmount - 1;
                if (detailDO.cobSavedAmount > 0)
                    detailDO.cobSavedAmount = detailDO.cobSavedAmount - 1;
                if (detailDO.convertedChargedAmount > 0)
                    detailDO.convertedChargedAmount = detailDO.convertedChargedAmount - 1;
                if (detailDO.disallowedAmount > 0)
                    detailDO.disallowedAmount = detailDO.disallowedAmount + 1;
                detailDO.lastAction = "C";
                detailDO.statusCode = "C";
            }
            request.messageCodeSC = request.messageCodeSC;
            request.lastAction = "C";
            request.statusCode = "C";
            request.totalClaim = request.totalClaim - 1;
            request.totalPaid = request.totalPaid - 1;

            return request;
        }

        public UBClaimDO UBClaimCalculate(UBClaimDO request)
        {
            if (request == null)
            {

                throw new ArgumentNullException("ClaimCalculateRequest");
            }

            return processClaimCalculateRequest(request);
        }

        public UBClaimDO processClaimCalculateRequest(UBClaimDO request)
        {

            return populateClaimCalculateResponse(request);
        }

        public UBClaimDO populateClaimCalculateResponse(UBClaimDO request)
        {


            foreach (UBDetailDO detailDO in request.detailOC)
            {
                if (detailDO.allowedAmount > 0)
                    detailDO.allowedAmount = detailDO.allowedAmount - 1;
                if (detailDO.chargedAmount > 0)
                    detailDO.chargedAmount = detailDO.chargedAmount - 1;
                if (detailDO.cobAmount > 0)
                    detailDO.cobAmount = detailDO.cobAmount - 1;
                if (detailDO.cobSavedAmount > 0)
                    detailDO.cobSavedAmount = detailDO.cobSavedAmount - 1;
                if (detailDO.convertedChargedAmount > 0)
                    detailDO.convertedChargedAmount = detailDO.convertedChargedAmount - 1;
                if (detailDO.disallowedAmount > 0)
                    detailDO.disallowedAmount = detailDO.disallowedAmount + 1;
                detailDO.lastAction = "C";
                detailDO.statusCode = "C";
            }
            request.messageCodeSC = request.messageCodeSC;
            request.lastAction = "C";
            request.statusCode = "C";
            request.totalClaim = request.totalClaim - 1;
            request.totalPaid = request.totalPaid - 1;

            return request;
        }


    }
}
