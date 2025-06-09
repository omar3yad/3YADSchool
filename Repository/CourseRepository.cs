using ITISchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ITISchool.Repository
{
    public class CourseRepository
    {
        ITISchoolContext context = new ITISchoolContext();
        public List<Course> GetAllCourses()
        {
            return context.Courses
                .Include(c => c.Department)
                .Include(c => c.Instructors)
                .ToList();
        }

        public Course GetCourseById(int id)
        {
            return context.Courses
                .Include(c => c.Department)
                .Include(c => c.Instructors)
                .Include(c => c.CrsResults)
                .ThenInclude(cr => cr.Trainee)
                .FirstOrDefault(c => c.Id == id);
        }

        public CourseDepartmentInstructors GetCourseForEdit(int id)
        {
            var course = context.Courses
                .Include(c => c.Department)
                .Include(c => c.Instructors)
                .FirstOrDefault(c => c.Id == id);

            if (course == null) return null;

            return new CourseDepartmentInstructors
            {
                Id = course.Id,
                Name = course.Name,
                Degree = course.Degree,
                MinDegree = course.MinDegree,
                hours = course.hours,
                DeptID = course.DeptId,
                departments = context.Departments.ToList(),
                instructors = context.Instructors
                    .Where(i => i.CrsId == 1004 || i.CrsId == id)
                    .ToList()
            };
        }

        public bool UpdateCourse(CourseDepartmentInstructors cdi)
        {
            var course = context.Courses
                .Include(c => c.Instructors)
                .FirstOrDefault(c => c.Id == cdi.Id);

            if (course == null) return false;

            course.Name = cdi.Name;
            course.Degree = cdi.Degree;
            course.MinDegree = cdi.MinDegree;
            course.hours = cdi.hours;
            course.DeptId = cdi.DeptID;

            var currentInstructors = context.Instructors.Where(i => i.CrsId == cdi.Id).ToList();
            var selectedInstructors = context.Instructors.Where(i => cdi.InstIDs.Contains(i.Id)).ToList();

            foreach (var instructor in currentInstructors)
                if (!cdi.InstIDs.Contains(instructor.Id))
                    instructor.CrsId = 1004;

            foreach (var instructor in selectedInstructors)
                instructor.CrsId = cdi.Id;

            context.SaveChanges();
            return true;
        }

        public void PopulateDropdowns(CourseDepartmentInstructors cdi)
        {
            cdi.departments = context.Departments.ToList();
        }

        public bool DeleteCourse(int id)
        {
            var course = context.Courses.Find(id);
            if (course == null) return false;

            context.Courses.Remove(course);
            context.SaveChanges();
            return true;
        }
    }
}
