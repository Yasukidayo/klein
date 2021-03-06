﻿using LivetApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivetApp1.Services
{
    interface IRestService
    {
        Task<User> LogonAsync(User user);
        Task<User> LogonAsync2(User user);

        // User REST API Client
        Task<List<User>> GetUsersAsync();
        Task<User> PostUserAsync(User user);
        Task<User> PutUserAsync(User user);
        Task<User> DeleteUserAsync(long Id);


        // TanksCard REST API Client
        Task<List<ThanksCard>> GetThanksCardsAsync();
        Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard);
        Task<ThanksCard> DeleteThanksCardAsync(long Id);

        // Department REST API Client
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> PostDepartmentAsync(Department department);
        Task<Department> PutDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(long Id);

        // DepartmentUsers REST API Client
        Task<List<User>> GetDepUsersAsync(long? DepartmentId);

        // Department REST API Client
        Task<List<Responsemessage>> GetResponsemessagesAsync();
        Task<Responsemessage> PostResponsemessageAsync(Responsemessage responsemessage);
        Task<Responsemessage> PutResponsemessageAsync(Responsemessage responsemessage);
        Task<Responsemessage> DeleteResponsemessageAsync(long Id);
    }
}