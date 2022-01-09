using System;
using Installments.Services;

namespace Installments.Services
{
    interface IOnlinePaymetService
    {
        double PaymentFee(double amount);
        double Interest(double amount, int curr_mouth);
    }
}
