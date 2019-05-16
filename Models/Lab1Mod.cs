namespace to.Models
{
    public class Lab1Mod
    {
        public string FIO { get; set; }
        public string Group { get; set; }
        public int Curs { get; set; }
        public int Number_stud { get; set; }
        public string Birth { get; set; }
        public string Place_live { get; set; }
        public string Comment { get; set; }
        public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();
            if (string.IsNullOrWhiteSpace(FIO))
            validationResult.Append($"FIO cannot be empty");
            if (string.IsNullOrWhiteSpace(Group))
            validationResult.Append($"Group cannot be empty");
            if (string.IsNullOrWhiteSpace(Birth))
            validationResult.Append($"Birth cannot be empty");
            if (string.IsNullOrWhiteSpace(Place_live))
            validationResult.Append($"Place_live cannot be empty");
            if (!(0 < Curs && Curs < 5))
            validationResult.Append($"Curs {Curs} is out of range (1..4)");
            if (!(0 < Number_stud && Number_stud < 999))
            validationResult.Append($"Number_stud {Number_stud} is out of range (0..999)");
            //if (!string.IsNullOrEmpty(FIO) && char.IsUpper(FIO.FirstOrDefault())) 
           // validationResult.Append($"FIO {FIO} should start from capital letter");
            return validationResult;
        }
        public override string ToString()
        {   
            return $"{Number_stud} {FIO} из {Group},{Curs} курс";
        }
    }
    
 }

