﻿using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Notenverwaltung.Core;
using Notenverwaltung.Core.Enums;
using Notenverwaltung.Core.Services;
using System.Threading.Tasks;

namespace Notenverwaltung.WPF.UI.ViewModels
{
    public class MenuViewModel : Notenverwaltung.Core.ViewModels.MenuViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="messenger">The messenger.</param>
        public MenuViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IUserPermissions userPermissions)
            : base(logProvider, navigationService)
        {
            this._navigationService = navigationService;
            this._userPermissions = userPermissions;

            this.ShowSubjectManagementCommand = new MvxAsyncCommand(() => this._navigationService.Navigate<SubjectManagementViewModel>());
            this.ShowStudentManagementCommand = new MvxAsyncCommand(() => this._navigationService.Navigate<StudentManagementViewModel>());
            this.ShowClassManagementCommand = new MvxAsyncCommand(() => this._navigationService.Navigate<ClassManagementViewModel>());
            this.ShowTeacherManagementCommand = new MvxAsyncCommand(() => this._navigationService.Navigate<TeacherManagementViewModel>());
            this.ShowGradeManagementCommand = new MvxAsyncCommand(() => this._navigationService.Navigate<GradeManagementViewModel>());
            this.ShowSettingsCommand = new MvxAsyncCommand(() => this._navigationService.Navigate<SettingsViewModel>());
        }

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>Initilisierung.</returns>
        public override Task Initialize()
        {
            return base.Initialize();
        }

        /// <summary>
        /// Prepares this instance. called after construction.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();
        }

        /// <summary>
        /// Views the appeared.
        /// </summary>
        public override void ViewAppeared()
        {
            base.ViewAppeared();

            // direkt zeigen
            ShowSubjectManagementCommand.Execute();
        }

        #endregion Methods

        #region Values

        private readonly IMvxNavigationService _navigationService;
        private readonly IUserPermissions _userPermissions;

        public bool ClassManagementViewable
        {
            get => _userPermissions.GetLookPermission(ModuleType.ClassManagement);
        }

        public bool GradeManagementViewable
        {
            get => _userPermissions.GetLookPermission(ModuleType.GradeManagement);
        }

        public IMvxAsyncCommand ShowClassManagementCommand { get; set; }

        public IMvxAsyncCommand ShowGradeManagementCommand { get; set; }

        public IMvxAsyncCommand ShowSettingsCommand { get; set; }

        public IMvxAsyncCommand ShowStudentManagementCommand { get; set; }

        public IMvxAsyncCommand ShowSubjectManagementCommand { get; set; }

        public IMvxAsyncCommand ShowTeacherManagementCommand { get; set; }

        public bool StudentManagementViewable
        {
            get => _userPermissions.GetLookPermission(ModuleType.StudentManagement);
        }

        public bool SubjectManagementViewable
        {
            get => _userPermissions.GetLookPermission(ModuleType.SubjectManagement);
        }

        public bool TeacherManagementViewable
        {
            get => _userPermissions.GetLookPermission(ModuleType.TeacherManagement);
        }

        #endregion Values
    }
}