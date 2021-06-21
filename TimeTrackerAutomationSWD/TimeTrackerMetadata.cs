namespace TimeTrackerAutomationSWD
{
    public static class TimeTrackerLoginPageMetadata
    {
        public const string LoginUrl = @"https://timetracker.bairesdev.com/";

        public const string UsernameTextBoxSelector = "#ctl00_ContentPlaceHolder_UserNameTextBox";

        public const string PasswordTextBoxSelector = "#ctl00_ContentPlaceHolder_PasswordTextBox";

        public const string LoginButtonSelector = "#ctl00_ContentPlaceHolder_LoginButton";
    }
    
    public static class TimeTrackerListPageMetadata
    {
        public const string TrackButtonSelector = "#main > p:nth-child(8) > a:nth-child(1)";
    }

    public static class TimeTrackerFormPageMetadata
    {
        public const string DateTextBoxSelector = "#ctl00_ContentPlaceHolder_txtFrom";
        
        public const string ProjectDropDownSelector = "#ctl00_ContentPlaceHolder_idProyectoDropDownList";
        
        public const string HoursTextBoxSelector = "#ctl00_ContentPlaceHolder_TiempoTextBox";
        
        public const string AssignmentTypeDropDownSelector = "#ctl00_ContentPlaceHolder_idTipoAsignacionDropDownList";
        
        public const string DescriptionTextBoxSelector = "#ctl00_ContentPlaceHolder_DescripcionTextBox";

        public const string FocalPointDropDownSelector = "#ctl00_ContentPlaceHolder_idFocalPointClientDropDownList";
        
        public const string AcceptButtonSelector = "#ctl00_ContentPlaceHolder_btnAceptar";
    }
}