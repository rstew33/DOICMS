using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Data
{
    public class Consumer
    {
    [Key] public int ConsumerID { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Address { get; set; }
    [Required] public string PhoneNumber { get; set; }
    //Public virtual List<Complaint> ComplaintsConsumer[fk - Complaints]

    }
}
