//using ITISchool.Migrations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITISchool.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

//Remove - Migration
//Add - Migration InitialCreate
//Update-Database
