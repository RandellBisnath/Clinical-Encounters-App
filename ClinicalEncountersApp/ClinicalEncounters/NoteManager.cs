using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicalEncounters
{
    public class NoteManager
    {
        public NoteManager()
        {
            // Create the file if it doesn't exist..
            if (!File.Exists(_fileName))
            {
                // Note: we dispose of it right away so it isn't locked
                File.Create(_fileName).Dispose();
            }

            // Otherwise open it and read into our list:
            ReadFromFileToList();
        }

        public List<Note> getAllNotes()
        {
            ReadFromFileToList();
            return _notes;
        }
        public void AddNote(Note note) 
        {
            _notes.Add(note);
            WriteListToFile();
        }

        public void RemoveNote(Note note)
        {
            for (int i = 0; i < _notes.Count;i++)
            {
                if (_notes[i] == note)
                {
                    _notes.RemoveAt(i);
                }
            }
            WriteListToFile();
        }

        public void UpdateNotes(Note note) 
        {
            for(int i = 0; i < _notes.Count; i++)
            {
                if(note.NoteID == _notes[i].NoteID)
                {
                    _notes[i] = note; break;
                }
            }

            WriteListToFile();
        }

        private void ReadFromFileToList()
        {
            using (StreamReader sr = new StreamReader(_fileName))
            {

                _notes.Clear();

                while (!sr.EndOfStream)
                {
                    string? currentRecord = sr.ReadLine();
                    if (currentRecord != null)
                    {
                        Note currentNotes = getNoteFromFile(currentRecord);
                        _notes.Add(currentNotes);
                    }
                }
            }
        }

        private static Note getNoteFromFile(string fileRecord)
        {
            string[] noteField = fileRecord.Split('|');
            int noteID = int.Parse(noteField[0]);
            string patientName = noteField[1];
            DateTime dateOfBirth = DateTime.Parse(noteField[2]);
            string[] problems = noteField[3].Split(';');
            string[] description = noteField[4].Split(";");

            return new Note()
            {
                NoteID = noteID,
                PatientName = patientName,
                DateOfBirth = dateOfBirth,
                Description = description,
                Problems = problems
            };
        }

        private void WriteListToFile()
        {
            using (StreamWriter writer = new StreamWriter(_fileName))
            {
                foreach (Note note in _notes)
                {
                    writer.Write(FormatNote(note));
                    foreach (var p in note.Problems)
                    {
                        writer.Write(p + ";");
                    }
                    writer.Write("|");
                    foreach (string line in note.Description)
                    {
                        writer.Write(line + ";");
                    }
                    writer.WriteLine("");
                }
            }
        }

        private static string FormatNote(Note note)
        {
            return $"{note.NoteID}|{note.PatientName}|{note.DateOfBirth}|";
        }
        public int GetNewID()
        {
            ReadFromFileToList();
            if (_notes.Count == 0)
            {
                return 1;
            }
            else
            {
                int noteWithMaxID = _notes[0].NoteID;
                for (int i = 0; i < _notes.Count; i++)
                {
                    if (noteWithMaxID < _notes[i].NoteID)
                    {
                        noteWithMaxID = _notes[i].NoteID;
                    }
                }

                return noteWithMaxID + 1;
            }
        }

        private const string _fileName = "notes.txt";
        private List<Note> _notes = new List<Note>();
    }
}
