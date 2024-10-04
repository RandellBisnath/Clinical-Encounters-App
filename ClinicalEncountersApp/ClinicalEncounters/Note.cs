namespace ClinicalEncounters
{
    public class Note
    {
        public int NoteID { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string[] Description { get; set; }
        public string[] Problems { get; set; }

        public override string ToString()
        {
            return $"Note: {NoteID}, Name: {PatientName}";
        }
    }
}