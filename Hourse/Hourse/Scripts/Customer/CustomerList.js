var app = new Vue({
    el: '#app',
    data: {
        test: "哇哈哈",
        CustomerInfoList: []
    },
    methods: {
        GetProducts() {
            console.log("HIHI");
            that = this;
            //$.busyLoadFull("show");
            //let __RequestVerificationToken = $('[name="__RequestVerificationToken"]').val();
            $.ajax({
                type: 'get',
                url: '/api/Products/GetProduct',
                data: {
                },
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                dataType: 'json',
                success: function (result) {
                    debugger;
                    that.CustomerInfoList = result
                    //$.busyLoadFull("hide");
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    //if (jqXHR.status !== 401) {
                    //    swal(jqXHR.responseText);
                    //}
                }
            })
        }
    },
    mounted() {
        this.GetProducts();
    }
})