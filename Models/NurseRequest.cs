using System.ComponentModel.DataAnnotations;

namespace SignalR8.Models;

public class NurseRequest
{
    
    [Key]
    public int  JobId   { get; set; }
    public DateTime ReqDate { get; set; }   
    public DateTime ReqTime { get; set; }
    public DateTime EndDate { get; set; }   
    public DateTime EndTime { get; set; }   
    public int UserId { get; set; } 
    public string Department { get; set; }= string.Empty;  
    public string StartPoint { get; set; }  = string.Empty;
    public string EndPoint { get; set; }    = string.Empty;
    public string MaterialType { get; set; }   = string.Empty; 
    public string UrentType { get; set; }   = string.Empty;
    public string PatientType { get; set; } = string.Empty;
    public string PoterFname { get; set; }  = string.Empty;
    public string Remark { get; set; }  = string.Empty;
    public int QN { get; set; } 
    public string QNName { get; set; }  = string.Empty;
    public string QNAge { get; set; }  = string.Empty; 
    public string QNSex { get; set; }  = string.Empty; 
}