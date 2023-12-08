const host = "https://provinces.open-api.vn/api/";
var callAPI = (api) => {
    return axios.get(api)
        .then((response) => {
            renderData(response.data, "city");
        });
}
callAPI('https://provinces.open-api.vn/api/?depth=1');
var callApiDistrict = (api) => {
    return axios.get(api)
        .then((response) => {
            renderData(response.data.districts, "district");
        });
}
var callApiWard = (api) => {
    return axios.get(api)
        .then((response) => {
            renderData(response.data.wards, "ward");
        });
}

var renderData = (array, select) => {
    let row = ' <option disable value="">Chọn</option>';
    array.forEach(element => {
        row += `<option data-id="${element.code}" value="${element.name}">${element.name}</option>`
    });
    document.querySelector("#" + select).innerHTML = row
}

$("#city").change(() => {
    callApiDistrict(host + "p/" + $("#city").find(':selected').data('id') + "?depth=2");
    printResult();
});
$("#district").change(() => {
    callApiWard(host + "d/" + $("#district").find(':selected').data('id') + "?depth=2");
    printResult();
});
$("#ward").change(() => {
    printResult();
})


//function AddToCart() {
//    var countCartItem = document.getElementById("CountCartProduct");
//    const _quantity = document.getElementById("value");
//    const id = document.getElementById("product_id");
//    var alert = document.getElementById("alertPaymentSuccess")
//    $.ajax({
//        url: '/Cart/AddToCart_JS',
//        type: "POST",
//        data: { product_id: id.value, quantity: _quantity.value },
//        success: function (res) {
//            if (res.success == true) {
//                alert.style.display = "block";
//                if (res.totalProduct > 0) {
//                    countCartItem.textContent = res.totalProduct;
//                }
//            }
//            else {
//                alert.style.display = "none";
//                countCartItem.textContent = 0;
//            }

           

//        }
//    })
//}
