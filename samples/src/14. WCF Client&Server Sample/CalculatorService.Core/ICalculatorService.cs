using System.ServiceModel;
using System.ServiceModel.Web;

namespace CalculatorService.Core
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        [WebGet]
        int Add(int a, int b);

        [OperationContract]
        [WebGet]
        int Multiple(int a, int b);

        [OperationContract]
        [WebGet]
        ulong Factorial(ulong range);
    }
}