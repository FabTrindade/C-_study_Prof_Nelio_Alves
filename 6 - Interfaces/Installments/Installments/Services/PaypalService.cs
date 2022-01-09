
using System;
using Installments.Services;
namespace Installments.Services
{
    class PaypalService : IOnlinePaymetService
    {
        public PaypalService()
        {
        }
        public double PaymentFee(double amount)
        {
            return amount * 0.02;
        }
        public double Interest(double amount, int curr_mouth)
        {
            return amount * curr_mouth * 0.01;
        }
    }
}
