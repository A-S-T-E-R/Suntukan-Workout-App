using System.Collections.Generic;
using SQLite;

namespace Boxing_Trainer_App
{
    public class DatabaseHelper
    {
        private SQLiteConnection db;

        public DatabaseHelper(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Exercise>();
        }

        public void AddExercise(int day, string exerciseName)
        {
            db.Insert(new Exercise { Day = day, ExercisesName = exerciseName });
        }

        public List<Exercise> GetExercisesForDay(int day)
        {
            return db.Table<Exercise>().Where(e => e.Day == day).ToList();
        }

        public void DeleteExercise(int id)
        {
            db.Delete<Exercise>(id);
        }

        public void UpdateExercise(int exerciseId, string newName)
        {
            var exercise = db.Table<Exercise>().FirstOrDefault(e => e.Id == exerciseId);
            if (exercise != null)
            {
                exercise.ExercisesName = newName;
                db.Update(exercise);
            }
        }

    }

    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Day { get; set; }
        public string ExercisesName { get; set; }
    }
}
