using System;
using Installments.Entities;
using Installments.Services;
namespace Installments.Services
{
    class ContractServices
    {

        private IOnlinePaymetService PaymentService;

        public ContractServices(IOnlinePaymetService paymentService)
        {
            PaymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int mouths)
        {
            double singleAmount = contract.TotalValue / mouths;

            for (int i = 1; i <= mouths; i++)
            {
                double paymentInterest = singleAmount + PaymentService.Interest(singleAmount, i);
                double installmentAmount = PaymentService.PaymentFee(paymentInterest) + paymentInterest;

                contract.AddInstallment(new Installment(contract.Date.AddMonths(i), installmentAmount));

            }
        }

    }
}
