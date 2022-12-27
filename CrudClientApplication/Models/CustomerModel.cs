using System.Collections.Generic;

namespace CrudClientApplication.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string OrderDetials { get; set; }
    }

    public class GetAllCustResponse
    {
        public List<CustomerModel> CustomerList { get; set; }

    }

    public class GetAllCustRequest
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
       

    }

    public class GetCustByIdCustResponse 
    {
        public CustomerModel Customer { get; set; }
    }

    public class CreateCustResponse 
    {
        public int Customerid { get; set; }

    }
    public class CreateCustRequest 
    {

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int OrderNumber { get; set; }
        public string OrderDetials { get; set; }

    }

    public class UpdateCustResponse 
    {
    }

    public class UpdateCustRequest 
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }

    public class DeleteCustResponse 
    {
        public int CustomerID { get; set; }
    }
    public class DeleteCustRequest 
    {
        public int CustomerID { get; set; }

    }

    public class GetjoinlistResponse
    {
        public List<CustomerModel> CustomerList { get; set; }
    }

}
