using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class LoginForm : Form {
        private LoginCtrl loginCtrl = new LoginCtrl();
        private ForgotPasswordCtrl forgotPasswordCtrl = new ForgotPasswordCtrl();
        private CreateUserCheckEmailCtrl CreateUserCheckEmailCtrl = new CreateUserCheckEmailCtrl();
        private CreateUsrCtrl createUserCtrl = new CreateUsrCtrl();

        public LoginForm() {
            InitializeComponent();

            // Control event handlers
            loginCtrl.LoginClicked += new EventHandler(loginCtrl_LoginClicked);
            loginCtrl.ForgotPasswordClicked += new EventHandler(loginCtrl_ForgotPasswordClicked);
            loginCtrl.CreateUserClicked += new EventHandler(loginCtrl_CreateUserClicked);

            forgotPasswordCtrl.ResetPasswordClicked += new EventHandler(forgotPasswordCtrl_ResetPasswordClicked);
            forgotPasswordCtrl.ResetPasswordCancelClicked += new EventHandler(forgotPasswordCtrl_ResetPasswordCancelClicked);

            CreateUserCheckEmailCtrl.CheckUserNameExistsClicked += new EventHandler(CreateUserCheckEmailCtrl_CheckUserNameExistsClicked);
            CreateUserCheckEmailCtrl.CheckUserNameCancelClicked += new EventHandler(CreateUserCheckEmailCtrl_CheckUserNameCancelClicked);

            createUserCtrl.CreateUserClicked += new EventHandler(createUserCtrl_CreateUserClicked);
            createUserCtrl.CreateUserBackClicked += new EventHandler(createUserCtrl_CreateUserBackClicked);
            createUserCtrl.CreateUserCancelClicked += new EventHandler(createUserCtrl_CreateUserCancelClicked);
        }

        private void LoginForm_Load(object sender, EventArgs e) {
            LoadControl(loginCtrl, "Login");
        }

        private void LoadControl(Control ctrl, string title) {
            this.Controls.Clear();
            //ctrl.Dock = DockStyle.Fill;
            this.Size = new Size(ctrl.Size.Width + 5, ctrl.Size.Height + 20);
            this.Text = title;
            this.Controls.Add(ctrl);
        }

        #region Login Ctrl
        void loginCtrl_LoginClicked(object sender, EventArgs e) {
            if (ValidateEmpty(loginCtrl.UserName, "user name") == false) return;
            if (ValidateEmpty(loginCtrl.Password, "password") == false) return;

            // TODO: check user name in valid email format

            object response = ServiceManager.Instance.Authenticate(loginCtrl.UserName, loginCtrl.Password);
            if (response != null) {
                TestService.UserInfo userInfo = (TestService.UserInfo)response;
                if (userInfo.Varified == false) {
                    VarifyForm varifyForm = new VarifyForm();
                    varifyForm.Email = userInfo.Email;
                    if (varifyForm.ShowDialog() == DialogResult.OK) {
                        this.DialogResult = DialogResult.OK;
                    }
                } else {
                    this.DialogResult = DialogResult.OK;
                }
            } else {
                MessageBox.Show("Authentication failed. Either user name or password is incorrect.", "Authenticate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void loginCtrl_ForgotPasswordClicked(object sender, EventArgs e) {
            LoadControl(forgotPasswordCtrl, "Forgot password");
        }

        void loginCtrl_CreateUserClicked(object sender, EventArgs e) {
            LoadControl(CreateUserCheckEmailCtrl, "Create an account");
        }
        #endregion

        #region Forgot password
        void forgotPasswordCtrl_ResetPasswordClicked(object sender, EventArgs e) {
            if (ValidateEmpty(forgotPasswordCtrl.UserName, "user name") == false) return;
            // TODO: validate email format

            object response = ServiceManager.Instance.ForgotPassword(forgotPasswordCtrl.UserName);
            if ((bool)response) {
                MessageBox.Show("Your password is successfully reset.", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadControl(loginCtrl, "Login");
            } else {
                MessageBox.Show("Password reset failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void forgotPasswordCtrl_ResetPasswordCancelClicked(object sender, EventArgs e) {
            LoadControl(loginCtrl, "Login");
        }
        #endregion

        #region Validate user name
        void CreateUserCheckEmailCtrl_CheckUserNameExistsClicked(object sender, EventArgs e) {
            if (ValidateEmpty(CreateUserCheckEmailCtrl.UserName, "user name") == false) return;

            if (InputValidator.ValidEmailFormat(CreateUserCheckEmailCtrl.UserName) == false) return;

            object response = ServiceManager.Instance.CheckUserExists(CreateUserCheckEmailCtrl.UserName);
            if ((bool)response) {
                MessageBox.Show("User name " + CreateUserCheckEmailCtrl.UserName + " already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                createUserCtrl.UserName = CreateUserCheckEmailCtrl.UserName;
                LoadControl(createUserCtrl, "Create user");
            }
        }

        void CreateUserCheckEmailCtrl_CheckUserNameCancelClicked(object sender, EventArgs e) {
            LoadControl(loginCtrl, "Login");
        }
        #endregion

        #region Create user
        void createUserCtrl_CreateUserClicked(object sender, EventArgs e) {
            if (ValidateEmpty(createUserCtrl.FirstName, "First Name") == false) return;
            if (ValidateEmpty(createUserCtrl.LastName, "Last Name") == false) return;
            if (ValidateEmpty(createUserCtrl.Company_Name, "Company Name") == false) return;
            if (ValidateEmpty(createUserCtrl.Password, "Password") == false) return;
            if (CompareValues(createUserCtrl.Password, createUserCtrl.ConfirmPassword, "Password", "Confirm Password") == false) return;

            TestService.UserInfo userInfo = new TestService.UserInfo();
            userInfo.TempId = Guid.NewGuid().ToString();
            userInfo.Email = createUserCtrl.UserName;
            userInfo.Password = createUserCtrl.Password;
            userInfo.FirstName = createUserCtrl.FirstName;
            userInfo.LastName = createUserCtrl.LastName;
            userInfo.CompanyName = createUserCtrl.Company_Name;
            userInfo.Varified = false;

            object response = ServiceManager.Instance.UpdateUserInfo(userInfo);
            if (response != null) {
                MessageBox.Show("New user name is successfully created. Please open your mailbox to see your login details and varification code", "Create user", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadControl(loginCtrl, "Login");
            }
        }

        void createUserCtrl_CreateUserBackClicked(object sender, EventArgs e) {
            LoadControl(CreateUserCheckEmailCtrl, "Create new user");
        }

        void createUserCtrl_CreateUserCancelClicked(object sender, EventArgs e) {
            LoadControl(loginCtrl, "Login");
        }
        #endregion

        private bool ValidateEmpty(string text, string name) {
            if (String.IsNullOrEmpty(text)) {
                MessageBox.Show(String.Format("{0} is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));
                return false;
            }
            return true;
        }

        private bool CompareValues(string val1, string val2, string val1_Name, string val2_Name) {
            if (val1.Equals(val2, StringComparison.OrdinalIgnoreCase) == false) {
                MessageBox.Show(String.Format("Values {0} and {1} do not match", val1_Name, val2_Name), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
