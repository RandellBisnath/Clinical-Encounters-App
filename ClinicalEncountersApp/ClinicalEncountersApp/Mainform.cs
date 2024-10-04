using ClinicalEncounters;
using System.Text.RegularExpressions;
namespace ClinicalEncountersApp
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }
        private Regex _bpPattern = new Regex(@"(BP:) (\d{2,3})/(\d{2,3})", RegexOptions.IgnoreCase);
        private Regex _hrPattern = new Regex(@"(HR:) (\d{2,3})", RegexOptions.IgnoreCase);
        private Regex _tempPattern = new Regex(@"(T:) (\d{2,3}).?(\d{1})?", RegexOptions.IgnoreCase);
        private Regex _rrPattern = new Regex(@"(RR:) (\d{2,3})", RegexOptions.IgnoreCase);
        private NoteManager _noteMngr = new NoteManager();
        private VitalManager _vitalMngr = new VitalManager();
        private Note _currentNote = new Note();

        private enum AppState {AwaitingNote, AddingNote, EditingNote};
        private AppState _currentAppState;

        private void UpdateUIControls(AppState newState)
        {
            _currentAppState= newState;
            if (_currentAppState == AppState.AwaitingNote)
            {
                txtPatientName.Text = string.Empty;
                txtNewProblem.Text = string.Empty;
                lstProblems.Items.Clear();
                lstVitals.Items.Clear();
                rtbNotes.Text = string.Empty;

                txtPatientName.Enabled= false;
                txtNewProblem.Enabled= false;
                rtbNotes.Enabled= false;
                btnMakeNewNote.Enabled = true;
                btnAddNote.Enabled= false;
                btnDeleteNote.Enabled= false;
                btnUpdateNote.Enabled= false;
                btnAddProblem.Enabled= false;
                btnDeleteProblem.Enabled= false;
                dtpDateOfBirth.Enabled= false;
                lstProblems.Enabled= false;
                lstVitals.Enabled= false;
            }
            else if (_currentAppState == AppState.AddingNote)
            {
                txtPatientName.Text = string.Empty;
                txtNewProblem.Text = string.Empty;
                lstProblems.Items.Clear();
                lstVitals.Items.Clear();
                rtbNotes.Text = string.Empty;

                txtPatientName.Enabled = true;
                txtNewProblem.Enabled = true;
                rtbNotes.Enabled = true;
                btnMakeNewNote.Enabled= false;
                btnAddNote.Enabled = true;
                btnDeleteNote.Enabled = false;
                btnUpdateNote.Enabled = false;
                btnAddProblem.Enabled = true;
                btnDeleteProblem.Enabled = true;
                dtpDateOfBirth.Enabled = true;
                lstProblems.Enabled = true;
                lstVitals.Enabled = true;
            }
            else if (_currentAppState == AppState.EditingNote)
            {
                txtPatientName.Enabled = true;
                txtNewProblem.Enabled = true;
                rtbNotes.Enabled = true;
                btnMakeNewNote.Enabled = true;
                btnAddNote.Enabled = false;
                btnDeleteNote.Enabled = true;
                btnUpdateNote.Enabled = true;
                btnAddProblem.Enabled = true;
                btnDeleteProblem.Enabled = true;
                dtpDateOfBirth.Enabled = true;
                lstProblems.Enabled = true;
                lstVitals.Enabled = true;
            }
        }
        private void loadNotesToListbox()
        {
            lstPatientNotes.Items.Clear();

            var notes = _noteMngr.getAllNotes();
            foreach (var note in notes)
            {
                lstPatientNotes.Items.Add(note);
            }
        }
        private void Mainform_Load(object sender, EventArgs e)
        {
            lblMsgs.Text = string.Empty;
            UpdateUIControls(AppState.AwaitingNote);
            try
            {
                _noteMngr.getAllNotes();
                loadNotesToListbox();
            }
            catch (Exception)
            {
                lblMsgs.Text += "Error Loading File";
            }
        }

        private void grpboxPatientInfo_Enter(object sender, EventArgs e)
        {

        }

        private void btnMakeNewNote_Click(object sender, EventArgs e)
        {
            UpdateUIControls(AppState.AddingNote);
            lstProblems.Items.Clear();
            lstVitals.Items.Clear();
            txtPatientName.Text = string.Empty;
            txtNewProblem.Text = string.Empty;
            rtbNotes.Text = string.Empty;
            lstPatientNotes.SelectedIndex = -1;
            int id = _noteMngr.GetNewID();
            txtNoteID.Text = id.ToString();

        }

        private void rtbNotes_TextChanged(object sender, EventArgs e)
        {
            string noteContent = rtbNotes.Text.Trim();
            if (!string.IsNullOrWhiteSpace(noteContent))
            {
                lstVitals.Items.Clear();
                Vitals currentVitals = new Vitals();

                currentVitals.BloodPressures = _vitalMngr.checkMatches(_bpPattern, noteContent);
                currentVitals.HeartRate = _vitalMngr.checkMatches(_hrPattern, noteContent);
                currentVitals.Temperature = _vitalMngr.checkMatches(_tempPattern, noteContent);
                currentVitals.RespiratoryRate = _vitalMngr.checkMatches(_rrPattern, noteContent);

                List<int> vitals = new List<int>();

                vitals = _vitalMngr.checkBloodPressure(currentVitals.BloodPressures);

                for (int i = 0; i < vitals.Count;)
                {
                    if (vitals[i] < 90 && vitals[i + 1] < 60)
                    {
                        lstVitals.Items.Add($"BP: {vitals[i]}/{vitals[i + 1]} (Low)");
                        i = i + 2;
                    }
                    else if (vitals[i] > 130 && vitals[i + 1] > 80)
                    {
                        lstVitals.Items.Add($"BP: {vitals[i]}/{vitals[i + 1]} (High)");
                        i = i + 2;
                    }
                    else
                    {
                        lstVitals.Items.Add($"BP: {vitals[i]}/{vitals[i + 1]}");
                        i = i + 2;
                    }
                }

                vitals = _vitalMngr.checkHRAndRR(currentVitals.HeartRate);
                for (int i = 0; i < vitals.Count; i++)
                {
                    if (vitals[i] <= 100 && vitals[i] >= 60)
                    {
                        lstVitals.Items.Add($"HR: {vitals[i]} bpm");
                    }
                    else if (vitals[i] > 100)
                    {
                        lstVitals.Items.Add($"HR: {vitals[i]} bpm (High)");
                    }
                    else if (vitals[i] < 60)
                    {
                        lstVitals.Items.Add($"HR: {vitals[i]} bpm (Low)");
                    }
                }

                List<double> temp = new List<double>();
                temp = _vitalMngr.checkTemp(currentVitals.Temperature);
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i] <= 37.2 && temp[i] >= 36.5)
                    {
                        lstVitals.Items.Add($"{temp[i]}° Celcius");
                    }
                    else if (temp[i] > 37.2)
                    {
                        lstVitals.Items.Add($"{temp[i]}° Celcius (High)");
                    }
                    else if (temp[i] < 36.5)
                    {
                        lstVitals.Items.Add($"{temp[i]}° Celcius (Low)");
                    }
                }

                vitals = _vitalMngr.checkHRAndRR(currentVitals.RespiratoryRate);
                for (int i = 0; i < vitals.Count; i++)
                {
                    if (vitals[i] <= 16 && vitals[i] >= 12)
                    {
                        lstVitals.Items.Add($"RR: {vitals[i]} bpm");
                    }
                    else if (vitals[i] > 16)
                    {
                        lstVitals.Items.Add($"RR: {vitals[i]} bpm (High)");
                    }
                    else if (vitals[i] < 12)
                    {
                        lstVitals.Items.Add($"RR: {vitals[i]} bpm (Low)");
                    }
                }
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            lstProblems.Items.Clear();
            lstVitals.Items.Clear();
            string errMsg = "";
            int noteID = int.Parse(txtNoteID.Text);

            string name = txtPatientName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                errMsg += "Error. No Name Detected. Please enter a name\n";
            }

            DateTime dob = dtpDateOfBirth.Value;
            if (dob > DateTime.Now)
            {
                errMsg += "Error. Date Selected is in the future. Please select Valid Date\n";
            }

            List<string> problems = new List<string>();
            for (int i = 0; i < lstProblems.Items.Count; i++)
            {
                string problem = lstProblems.Items[i].ToString();
                problems.Add(problem);
            }

            string[] description = rtbNotes.Text.Split("\n");

            if (errMsg != "")
            {
                lblMsgs.Text = errMsg;
            }
            else
            {
                Note currentNote = new Note();
                currentNote.NoteID = noteID;
                currentNote.PatientName = name;
                currentNote.DateOfBirth = dob;
                currentNote.Problems = problems.ToArray();
                currentNote.Description = description;

                _noteMngr.AddNote(currentNote);

                lblMsgs.Text = "Note Succesfully Added!";
                txtNewProblem.Text = string.Empty;
                txtNoteID.Text = string.Empty;
                txtPatientName.Text = string.Empty;
                rtbNotes.Text = string.Empty;
                lstProblems.Items.Clear();
                lstVitals.Items.Clear();
                lstPatientNotes.SelectedIndex= -1;
                loadNotesToListbox();
                UpdateUIControls(AppState.AwaitingNote);
            }
        }

        private void btnAddProblem_Click(object sender, EventArgs e)
        {
            string problem = txtNewProblem.Text;
            lblMsgs.Text = string.Empty;

            if (string.IsNullOrEmpty(problem))
            {
                lblMsgs.Text += "Error. No Problem detected. please enter problem\n";
            }
            else
            {
                lstProblems.Items.Add(problem);
                txtNewProblem.Text = string.Empty;
                lblMsgs.Text = "Problem Successfully Added!";
            }
        }

        private void btnDeleteProblem_Click(object sender, EventArgs e)
        {
            lblMsgs.Text = string.Empty;
            if (lstProblems.SelectedIndex == -1)
            {
                lblMsgs.Text += "Error. No Problem selected. Please select Problem to delete\n";
            }
            else
            {
                int selectedIndex = lstProblems.SelectedIndex;
                lstProblems.Items.RemoveAt(selectedIndex);
                lblMsgs.Text = "Problem Successfully deleted!";
            }
        }

        private void lstPatientNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNewProblem.Text = string.Empty;
            txtNoteID.Text = string.Empty;
            txtPatientName.Text = string.Empty;
            rtbNotes.Text = string.Empty;
            lstProblems.Items.Clear();
            lstVitals.Items.Clear();

            if (lstPatientNotes.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                _currentNote = lstPatientNotes.SelectedItem as Note;
                txtNoteID.Text = _currentNote.NoteID.ToString();
                txtPatientName.Text = _currentNote.PatientName;
                foreach (var line in _currentNote.Description)
                {
                    rtbNotes.Text += line + "\n";
                }

                foreach (var p in _currentNote.Problems)
                {
                    lstProblems.Items.Add(p);
                }
                UpdateUIControls(AppState.EditingNote);
            }
        }

        private void btnUpdateNote_Click(object sender, EventArgs e)
        {
            lstProblems.Items.Clear();
            lstVitals.Items.Clear();
            txtPatientName.Text = string.Empty;
            txtNewProblem.Text = string.Empty;
            rtbNotes.Text = string.Empty;
            lstPatientNotes.SelectedIndex = -1;
            string errMsg = "";
            string name = txtPatientName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                errMsg += "Error. No Name Detected. Please enter a name\n";
            }

            DateTime dob = dtpDateOfBirth.Value;
            if (dob > DateTime.Now)
            {
                errMsg += "Error. Date Selected is in the future. Please select Valid Date\n";
            }

            if (errMsg == "") {
                _currentNote.NoteID = int.Parse(txtNoteID.Text);
                _currentNote.PatientName = txtPatientName.Text;
                _currentNote.DateOfBirth = dtpDateOfBirth.Value;
                
                for(int i = 0; i < lstProblems.Items.Count; i++)
                {
                    _currentNote.Problems[i] = lstProblems.Items[i].ToString();
                }

                string[] description = rtbNotes.Text.Split("\n");
                _currentNote.Description = description;

                _noteMngr.UpdateNotes(_currentNote);
                loadNotesToListbox();
                UpdateUIControls(AppState.AwaitingNote);
            }
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstPatientNotes.SelectedIndex;
            if(selectedIndex == -1)
            {
                lblMsgs.Text = "Error. Please select patient notes you wish to delete.";
                return;
            }
            _currentNote = lstPatientNotes.SelectedItem as Note;
            _noteMngr.RemoveNote(_currentNote);
            loadNotesToListbox();
            txtNewProblem.Text = string.Empty;
            txtNoteID.Text = string.Empty;
            txtPatientName.Text = string.Empty;
            rtbNotes.Text = string.Empty;
            lstProblems.Items.Clear();
            lstVitals.Items.Clear();
            lstPatientNotes.SelectedIndex = -1;
            UpdateUIControls(AppState.AwaitingNote);
        }
    }
}