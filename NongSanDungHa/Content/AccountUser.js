
//$(document).on("click", "button[name='Edit']", function () {
//    var idItem = $(this).closest("tr").attr("id");
//    $.ajax({
//        url: "/Admin/AccountUser/JsonDetail/" + idItem,
//        type: "GET",
//        success: function (result) {
//            $("#user_id").val(idItem);
//            $("#username").val(result.user_username);
//            $("#username").prop("readonly", true);
//            $("#password").val(result.user_password);
//            $("#password").prop("readonly", false);
//            $("#firstname").val(result.user_firstname);
//            $("#firstname").prop("readonly", false);
//            $("#lastname").val(result.user_lastname);
//            $("#lastname").prop("readonly", false);
//            $("#gender").val(result.user_gender);
//            $("#gender").prop("readonly", false);
//            $("#address").val(result.user_address);
//            $("#address").prop("readonly", false);
//            $("#email").val(result.user_email);
//            $("#email").prop("readonly", false);
//            $("#phonenumber").val(result.user_phonenumber);
//            $("#phonenumber").prop("readonly", false);
//            $("#tier").val(result.user_member_tier);
//            $("#tier").prop("readonly", true);
//            $("#point").val(result.user_point);
//            $("#point").prop("readonly", true);

//            $("#btn-savechanges").show();
//            $("#ModalView").modal();
//        },
//        error: function () {
//            console.log("Lay thong tin chi tiet that bai");
//        }
//    })


//});
//$(document).on("click", "button[name='save-user']", function () {
//    let idItem = $("#user_id").val().trim();
//    let username = $("#username").val();
//    let password = $("#password").val();
//    let firstname = $("#firstname").val();
//    let lastname = $("#lastname").val();
//    let gender = $("#gender").val();
//    let address = $("#address").val();
//    let email = $("#email").val();
//    let phonenumber = $("#phonenumber").val();
//    let tier = $("#tier").val();
//    let point = $("#point").val();
//    if (idItem.length == 0) {
//        $.ajax({
//            url: "/Admin/AccountUser/JsonAdd",
//            data: {
//                item: { user_account_id: idItem, user_username: username, user_password: password, user_gender: gender, user_email: email, user_phonenumber: phonenumber, user_address: address, user_firstname: firstname, user_lastname: lastname, user_member_tier: tier, user_point: point }
//            },
//            type: "POST",
//            success: function (result) {
//                if (result.Success == true) {


//                    $("#ModalView").modal("hide");


//                    $("#alert_delete_failed").css("display", "none");

//                    LoadUserAccount();
//                }
//                else {
//                    $("#alert_delete_failed").html("Thêm thất bại");
//                    $("#alert_delete_failed").css("display", "inline");
//                    setTimeout(() => {
//                        $("#alert_delete_failed").css("display", "none");
//                    }, 5000)
//                }
//            }
//        })
//    }
//    else {
//        $.ajax({
//            url: "/Admin/AccountUser/JsonEdit",
//            data: {
//                item: { user_account_id: idItem, user_username: username, user_password: password, user_gender: gender, user_email: email, user_phonenumber: phonenumber, user_address: address, user_firstname: firstname, user_lastname: lastname, user_member_tier: tier, user_point: point }
//            },
//            type: "POST",
//            success: function (result) {
//                if (result.Success == true) {

//                    $("#ModalView").modal("hide");

//                    $("#alert_delete_failed").css("display", "none");

//                    LoadUserAccount();
//                }
//                else {
//                    $("#alert_delete_failed").html("Lưu thất bại");
//                    $("#alert_delete_failed").css("display", "inline");
//                    setTimeout(() => {
//                        $("#alert_delete_failed").css("display", "none");
//                    }, 5000)
//                }
//            }
//        })
//    }

//})
//$(document).on("click", "button=[name='add-user']", function () {
//    $("#user_id").val('');
//    $("#username").val('');
//    $("#username").prop("readonly", true);
//    $("#password").val('');
//    $("#password").prop("readonly", false);
//    $("#firstname").val('');
//    $("#firstname").prop("readonly", false);
//    $("#lastname").val(result.user_lastname);
//    $("#lastname").prop("readonly", false);
//    $("#gender").val(result.user_gender);
//    $("#gender").prop("readonly", false);
//    $("#address").val(result.user_address);
//    $("#address").prop("readonly", false);
//    $("#email").val(result.user_email);
//    $("#email").prop("readonly", false);
//    $("#phonenumber").val(result.user_phonenumber);
//    $("#phonenumber").prop("readonly", false);
//    $("#tier").val(result.user_member_tier);
//    $("#tier").prop("readonly", true);
//    $("#point").val(result.user_point);
//    $("#point").prop("readonly", true);
//    $("#ModalView").modal();
//})





//Account User
$(document).ready(function () {

    LoadUserAccount();
    LoadAdminAccount();
})
function LoadUserAccount() {
    $.ajax(
        {
            url: "/Admin/AccountUser/GetData",
            type: "GET",
            success: function (res) {
                
                if (res.TotalUser > 0) {
                    $("#user-account-content").empty();
                    var html = "";
                    var items = res.data;
                    for (let i = 0; i < res.TotalUser; i++) {
                        html += "<tr id='" + items[i].user_account_id + "'>";
                        html += "<td>" + items[i].user_username + " </td>";
                        html += "<td>" + items[i].user_password + " </td>";
                        html += "<td>" + items[i].user_gender + " </td>";
                        html += "<td>" + items[i].user_email + " </td>";
                        html += "<td>" + items[i].user_phonenumber + " </td>";
                        html += "<td>" + items[i].user_address + " </td>";
                        html += "<td>" + items[i].user_firstname + " </td>";
                        html += "<td>" + items[i].user_lastname + " </td>";
                        html += "<td>" + items[i].user_member_tier + " </td>";
                        html += "<td>" + items[i].user_point + " </td>";
                        html += "<td><button type='button' name='View' data-bs-toggle='modal' onclick='return User_Details(" + items[i].user_account_id + ")' data-bs-target='#ModalView'   class='btn btn-success me-1'><i class='fas fa-eye'></i></button>   <a class='btn btn-warning me-2' href='/Admin/AccountUser/Edit/" + items[i].user_account_id + "') '><i class='fas fa-edit'></i></a>";
                        html += "<button type='button' class='btn btn-danger' data-bs-toggle='modal' data-bs-target='#exampleModal'> <i class='fas fa-trash-alt'></i> </button > " +
                            "<div class='modal fade' id='exampleModal' tabindex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true'>" +
                            " <div class='modal-dialog'>" +
                            "<div class='modal-content'>" +
                            "<div class='modal-header'>" +
                            "<h5 class='modal-title' id='exampleModalLabel'>Thông Báo</h5>" +
                            "<button type='button' class='btn-close' data-bs-dismiss='modal' aria-label='Close'></button>" +
                            "</div>" +
                            "<div class='modal-body'>" +
                            "Bạn có chắc muốn xóa "+items[i].user_username +"?" +
                            "</div>" +
                            "<div class='modal-footer'>" +
                            "<button type='button' class='btn btn-secondary' data-bs-dismiss='modal'>Close</button>" +
                            "<button type='button' class='btn btn-danger' onclick='User_DeleteUser(" + items[i].user_account_id + ")'>Xóa</button>" +
                            "</div>" +
                            "</div>" +
                            "</div>" +
                            "</div>";
                        html += "</td>"
                        html += "</tr>";


                    }
                    $("#user-account-content").html(html);

                }
            }
        }
    )
}

function User_DeleteUser(idItem) {

    $.ajax(
        {
            url: "/Admin/AccountUser/JsonDelete/" + idItem,
            type: "POST",
            success: function (result) {
                if (result.Success == true) {

                    $("#alert_delete_failed").css("display", "none");
                    LoadUserAccount();
                }
                else {

                    $("#alert_delete_failed").css("display", "inline");
                    setTimeout(() => {
                        $("#alert_delete_failed").css("display", "none");
                    }, 5000)


                }

            },
            error: function () {
                console.log("Xoa that bai");
            }

        });
}
function User_Details(idItem) {
    $.ajax(
        {
            url: "/Admin/AccountUser/JsonDetail/" + idItem,
            type: "GET",
            success: function (result) {
              
                $("#username").val(result.user_username);
                $("#username").prop("readonly", true);
                $("#password").val(result.user_password);
                $("#password").prop("readonly", true);
                $("#firstname").val(result.user_firstname);
                $("#firstname").prop("readonly", true);
                $("#lastname").val(result.user_lastname);
                $("#lastname").prop("readonly", true);
                $("#gender").val(result.user_gender);
                $("#gender").prop("readonly", true);
                $("#address").val(result.user_address);
                $("#address").prop("readonly", true);
                $("#email").val(result.user_email);
                $("#email").prop("readonly", true);
                $("#phonenumber").val(result.user_phonenumber);
                $("#phonenumber").prop("readonly", true);
                $("#tier").val(result.user_member_tier);
                $("#tier").prop("readonly", true);
                $("#point").val(result.user_point);
                $("#point").prop("readonly", true);

                $("#btn-savechanges").hide();
                $("#ModalView").modal();
            },
            error: function () {
                console.log("Lay thong tin chi tiet that bai");
            }

        }
    )
}

//--Admin Account
function LoadAdminAccount() {
    $.ajax(
        {
            url: "/Admin/AccountAdmin/GetData",
            type: "GET",
            success: function (res) {

                if (res.TotalUser > 0) {
                    $("#admin-account-content").empty();
                    var html = "";
                    var items = res.data;
                    for (let i = 0; i < res.TotalUser; i++) {
                        html += "<tr id='" + items[i].admin_account_id + "'>";
                        html += "<td>" + items[i].admin_username + " </td>";
                        html += "<td>" + items[i].admin_password + " </td>";
                        html += "<td><button type='button' name='View' data-bs-toggle='modal' onclick='return Admin_Details(" + items[i].admin_account_id + ")' data-bs-target='#ModalView'   class='btn btn-success me-1'><i class='fas fa-eye'></i></button>   <a class='btn btn-warning me-2' href='/Admin/AccountAdmin/Edit/" + items[i].admin_account_id + "') '><i class='fas fa-edit'></i></a>";
                        html += "<button type='button' class='btn btn-danger' data-bs-toggle='modal' data-bs-target='#exampleModal'> <i class='fas fa-trash-alt'></i> </button > " +
                            "<div class='modal fade' id='exampleModal' tabindex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true'>" +
                            " <div class='modal-dialog'>" +
                            "<div class='modal-content'>" +
                            "<div class='modal-header'>" +
                            "<h5 class='modal-title' id='exampleModalLabel'>Thông Báo</h5>" +
                            "<button type='button' class='btn-close' data-bs-dismiss='modal' aria-label='Close'></button>" +
                            "</div>" +
                            "<div class='modal-body'>" +
                            "Bạn có chắc muốn xóa " + items[i].admin_username + "?" +
                            "</div>" +
                            "<div class='modal-footer'>" +
                            "<button type='button' class='btn btn-secondary' data-bs-dismiss='modal'>Close</button>" +
                            "<button type='button' class='btn btn-danger' onclick='Admin_DeleteAdmin(" + items[i].admin_account_id + ")'>Xóa</button>" +
                            "</div>" +
                            "</div>" +
                            "</div>" +
                            "</div>";
                        html += "</td>"
                        html += "</tr>";


                    }
                    $("#admin-account-content").html(html);

                }
            }
        }
    )
}

function Admin_DeleteAdmin(idItem) {

    $.ajax(
        {
            url: "/Admin/AccountAdmin/JsonDelete/" + idItem,
            type: "POST",
            success: function (result) {
                if (result.Success == true) {

                    $("#alert_delete_failed").css("display", "none");
                    LoadUserAccount();
                }
                else {

                    $("#alert_delete_failed").css("display", "inline");
                    setTimeout(() => {
                        $("#alert_delete_failed").css("display", "none");
                    }, 5000)


                }

            },
            error: function () {
                console.log("Xoa that bai");
            }

        });
}

function Admin_Details(idItem) {
    $.ajax(
        {
            url: "/Admin/AccountAdmin/JsonDetail/" + idItem,
            type: "GET",
            success: function (result) {

                $("#username").val(result.admin_username);
                $("#username").prop("readonly", true);
                $("#password").val(result.admin_password);
                $("#password").prop("readonly", true);
    

                $("#btn-savechanges").hide();
                $("#ModalView").modal();
            },
            error: function () {
                console.log("Lay thong tin chi tiet that bai");
            }

        }
    )
}

function DeleteUserOrder(idItem) {

    $.ajax(
        {
            url: "/Admin/AccountAdmin/JsonDelete/" + idItem,
            type: "POST",
            success: function (result) {
                if (result.Success == true) {

                    $("#alert_delete_failed").css("display", "none");
                    LoadUserAccount();
                }
                else {

                    $("#alert_delete_failed").css("display", "inline");
                    setTimeout(() => {
                        $("#alert_delete_failed").css("display", "none");
                    }, 5000)


                }

            },
            error: function () {
                console.log("Xoa that bai");
            }

        });
}

function Admin_Details(idItem) {
    $.ajax(
        {
            url: "/Admin/AccountAdmin/JsonDetail/" + idItem,
            type: "GET",
            success: function (result) {

                $("#username").val(result.admin_username);
                $("#username").prop("readonly", true);
                $("#password").val(result.admin_password);
                $("#password").prop("readonly", true);


                $("#btn-savechanges").hide();
                $("#ModalView").modal();
            },
            error: function () {
                console.log("Lay thong tin chi tiet that bai");
            }

        }
    )
}

function LoadUserOrder() {
    $.ajax(
        {
            url: "/Admin/user_order/GetData",
            type: "GET",
            success: function (res) {

                if (res.TotalUser > 0) {
                    $("#admin-account-content").empty();
                    var html = "";
                    var items = res.data;
                    for (let i = 0; i < res.TotalUser; i++) {
                        html += "<tr id='" + items[i].admin_account_id + "'>";
                        html += "<td>" + items[i].admin_username + " </td>";
                        html += "<td>" + items[i].admin_password + " </td>";
                        html += "<td><button type='button' name='View' data-bs-toggle='modal' onclick='return Admin_Details(" + items[i].admin_account_id + ")' data-bs-target='#ModalView'   class='btn btn-success me-1'><i class='fas fa-eye'></i></button>   <a class='btn btn-warning me-2' href='/Admin/AccountAdmin/Edit/" + items[i].admin_account_id + "') '><i class='fas fa-edit'></i></a>";
                        html += "<button type='button' class='btn btn-danger' data-bs-toggle='modal' data-bs-target='#exampleModal'> <i class='fas fa-trash-alt'></i> </button > " +
                            "<div class='modal fade' id='exampleModal' tabindex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true'>" +
                            " <div class='modal-dialog'>" +
                            "<div class='modal-content'>" +
                            "<div class='modal-header'>" +
                            "<h5 class='modal-title' id='exampleModalLabel'>Thông Báo</h5>" +
                            "<button type='button' class='btn-close' data-bs-dismiss='modal' aria-label='Close'></button>" +
                            "</div>" +
                            "<div class='modal-body'>" +
                            "Bạn có chắc muốn xóa " + items[i].admin_username + "?" +
                            "</div>" +
                            "<div class='modal-footer'>" +
                            "<button type='button' class='btn btn-secondary' data-bs-dismiss='modal'>Close</button>" +
                            "<button type='button' class='btn btn-danger' onclick='Admin_DeleteAdmin(" + items[i].admin_account_id + ")'>Xóa</button>" +
                            "</div>" +
                            "</div>" +
                            "</div>" +
                            "</div>";
                        html += "</td>"
                        html += "</tr>";


                    }
                    $("#admin-account-content").html(html);

                }
            }
        }
    )
}
