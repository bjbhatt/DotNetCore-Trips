using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trips.Models;

namespace Trips.Persistence
{
    public interface IOrganizationRepository
    {
        Task<ICollection<Institute>> ListInstitute();
        Task<Institute> GetInstitute(int instituteId);
        void AddInstitute(Institute institute);
        Task<ICollection<Institute>> FindInstitutes(Expression<Func<Institute, bool>> predicate);
        Task<Institute> FindSingleInstitute(Expression<Func<Institute, bool>> predicate);
        
        Task<ICollection<Division>> ListDivision();
        Task<Division> GetDivision(int divisionId);
        void AddDivision(Division division);
        Task<ICollection<Division>> FindDivisions(Expression<Func<Division, bool>> predicate);
        Task<Division> FindSingleDivision(Expression<Func<Division, bool>> predicate);

        Task<ICollection<Branch>> ListBranch();
        Task<Branch> GetBranch(int branchId);
        void AddBranch(Branch branch);
        Task<ICollection<Branch>> FindBranches(Expression<Func<Branch, bool>> predicate);
        Task<Branch> FindSingleBranch(Expression<Func<Branch, bool>> predicate);

        Task<ICollection<Can>> ListCan();
        Task<Can> GetCan(int canId);
        void AddCan(Can can);
        Task<ICollection<Can>> FindCans(Expression<Func<Can, bool>> predicate);
        Task<Can> FindSingleCan(Expression<Func<Can, bool>> predicate);

        Task<ICollection<InvitationalTraveler>> ListInvitationalTraveler();
        Task<InvitationalTraveler> GetInvitationalTraveler(int invitationalTravelerId);
        void AddInvitationalTraveler(InvitationalTraveler invitationalTraveler);
        Task<ICollection<InvitationalTraveler>> FindInvitationalTravelers(Expression<Func<InvitationalTraveler, bool>> predicate);
        Task<InvitationalTraveler> FindSingleInvitationalTraveler(Expression<Func<InvitationalTraveler, bool>> predicate);
    }
}