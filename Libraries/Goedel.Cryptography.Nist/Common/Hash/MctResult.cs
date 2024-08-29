namespace Goedel.Cryptography.Nist;
public class MctResult<T> {
        public List<T> Response { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success => string.IsNullOrEmpty(ErrorMessage);

        public MctResult(List<T> responses) {
            Response = responses;
            }

        public MctResult(string errorMessage) {
            ErrorMessage = errorMessage;
            }
        }
    
