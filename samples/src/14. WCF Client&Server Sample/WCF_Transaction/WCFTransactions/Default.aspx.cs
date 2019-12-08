using System;
using System.Web.UI;
using System.Transactions;
namespace WCFTransactions
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                var obj = new ServiceReference1.Service1Client();
                obj.UpdateData();
                var obj1 = new ServiceReference2.Service1Client();
                obj1.UpdateData();
                ts.Complete();
            }
        }
    }
}
