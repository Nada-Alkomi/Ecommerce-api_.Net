namespace e_commerce.BLL.DTOs;

public class CommonRespons
{
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess{ get; set;}
    public object AdditionalInfo { get; set; } = new();
    
    public List<string> Errors { get; set; }
    
    public CommonRespons( string _magsage , bool _isSuccess, object _additionalInfo= null!, List<string> _errors=null!)
    {
        Message = _magsage;
        IsSuccess = _isSuccess;
        AdditionalInfo = _additionalInfo;
        Errors = _errors;
    }   
    
       
    
}