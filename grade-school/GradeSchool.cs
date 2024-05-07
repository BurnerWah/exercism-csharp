using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool {
    private readonly Dictionary<string, int> students = [];

    public bool Add(string student, int grade) => students.TryAdd(student, grade);

    public IEnumerable<string> Roster() => from student in students
                                           orderby student.Value, student.Key
                                           select student.Key;

    public IEnumerable<string> Grade(int grade) => from student in students
                                                   where student.Value == grade
                                                   orderby student.Key
                                                   select student.Key;
}
