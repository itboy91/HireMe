<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndividualProfile.aspx.cs" Inherits="HireMe.UI.Pages.Individual.IndividualProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-success" runat="server" id="divSuccess">
                     you completed your regestrtion 
                    </div>
    <script src="../../Scripts/bootstrap-multiselect.js"></script>
    <script>   
        $(function () {
            SetMultiSelect();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandle);
            function endRequestHandle(sender, Args) {
                SetMultiSelect();
            };
        });

        function SetMultiSelect() {
            $('[id*=lstSkils]').multiselect({
                includeSelectAllOption: true,
                buttonWidth: '525px',
                dropRight: true
            });
        }

    </script>
    <style type="text/css">
        .multiselect-container {
            width: 100% !important;
        }
    </style>
 
        <h2>Individual Profile</h2>
        <div class="panel panel-success">
            <div class="panel-heading">Basic Informationt</div>
            <div class="panel-body">
                <div class="">
                 
                    <div class="row">
                    
                        <div class="col-lg-6">
                            <div class="form-group">
                                <asp:Image ID="Image1" Visible = "false" runat="server" Height = "200" Width = "200"  CssClass="img-thumbnail"/>

                                </div>
                        </div>
                            <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                            <div class="col-lg-6">
                            <div class="form-group">
                                <asp:FileUpload ID="fubImage" runat="server" />
                                 <asp:RequiredFieldValidator ID="fImage" ControlToValidate="fubImage" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" ValidationGroup="v2"></asp:RequiredFieldValidator>

                                <asp:Button ID="btnUpload" runat="server" Text="Upload" ValidationGroup="vs"
                                    OnClick="btnUpload_Click" />
                            </div>
                        </div>
                           </ContentTemplate>
                                 <Triggers>
        <asp:PostBackTrigger ControlID = "btnUpload" />
    </Triggers>
                         </asp:UpdatePanel>
                    </div>
                     
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault">Full Name:</label>
                                <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rfvtxtPassword" ControlToValidate="txtFullName" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" ValidationGroup="v1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault">Email:</label>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" Enabled="false" ValidationGroup="v1"></asp:TextBox>

                                
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="sel1">Location:</label>
                                <asp:DropDownList ID="ddlLocation" runat="server" class="form-control"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlLocation" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault">phone:</label>
                                <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPhone" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="sel1">Birth Of date:</label>
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlYear" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="sel1"></label>
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlMonth" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="sel1"></label>
                                <asp:DropDownList ID="ddlDay" runat="server" CssClass="form-control"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlDay" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="sel1">gender:</label>
                                <asp:DropDownList ID="ddlGendr" runat="server" class="form-control"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlGendr" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" InitialValue="Please select"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="sel1">Nationality:</label>
                                <asp:DropDownList ID="ddlNationality" runat="server" class="form-control"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlNationality" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" InitialValue="Please select"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="sel1">Relationship Status</label>
                                <asp:DropDownList ID="ddlRelationshipStatus" runat="server" class="form-control"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlRelationshipStatus" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!"  InitialValue="Please select"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="sel1">ability to travel :</label>
                                <asp:DropDownList ID="ddlAbilityToTravel" runat="server" class="form-control"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlAbilityToTravel" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!"  InitialValue="Please select"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-warning">
            <div class="panel-heading">Career Information</div>
            <div class="panel-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="sel1">field of business:</label>
                                    <asp:DropDownList ID="ddlFieldOfBusiness" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlFieldOfBusiness_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="sel1">skiles:</label><br>
                                    <asp:ListBox ID="lstSkils" runat="server" SelectionMode="Multiple" Style="width: 100px;" Enabled="false"></asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="sel1">graduation country:</label>
                                   
                                    <asp:DropDownList ID="ddlGraduationCountry" AutoPostBack="true" OnSelectedIndexChanged="ddlGraduationCountry_SelectedIndexChanged" runat="server" class="form-control"></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddlGraduationCountry" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" InitialValue="Please select"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="sel1">graduation university :</label>
                                    <asp:DropDownList ID="ddlGraduationUniversity" Enabled="false" runat="server" CssClass="form-control"></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="ddlGraduationUniversity" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" InitialValue="Please select"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="sel1">Years of experience:</label>
                            <asp:DropDownList ID="ddlYearsOfExperience" runat="server" class="form-control"></asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="ddlYearsOfExperience" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" InitialValue="Please select"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="sel1">type of employment:</label>
                            <asp:DropDownList ID="ddlTypeOfEmployment" runat="server" class="form-control"></asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddlTypeOfEmployment" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" InitialValue="Please select"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault">Minimum Salary:</label> (USD)
                                <asp:TextBox runat="server" ID="txtMinimumSalary" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtMinimumSalary" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" InitialValue="Please select"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault"> Employment History </label>
                                <asp:TextBox runat="server" TextMode="MultiLine" Style="min-height: 150px;" ID="txtEmploymentHistory" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="txtEmploymentHistory" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" InitialValue="Please select"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="sel1">Academic Degree:</label>
                            <asp:DropDownList ID="ddlAcademicDegree" runat="server" class="form-control"></asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="ddlAcademicDegree" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" InitialValue="Please select"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="inputdefault">Upload Your CV:</label>
                            <asp:FileUpload ID="fuCv" runat="server" />

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Button ID="btnDownload" runat="server" Text="Download File"
                                OnClick="btnDownload_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                      
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label for="inputdefault"> Cover letter </label>(Why Should We Hire You)
                                <asp:TextBox runat="server" TextMode="MultiLine" Style="min-height: 150px;" ID="txtCoverletter" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="txtEmploymentHistory" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" InitialValue="Please select"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
        <div class="col-lg-6">
            <asp:Button ID="btnSave" runat="server" Style="width: 150px; margin: -8px;" CssClass="btn btn-primary btn-lg" Text="save" OnClick="btnSave_Click" />
        </div>
 

</asp:Content>


