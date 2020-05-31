var app = new Vue({
    el: '#app',
    data: {
        CustomerInfoList: [],
        NewOrUpdateCustermer: {
            Id:0,
            CustomerName: "",
            Phone: "",
            Address:""
        },
        IsEdit: false,
        SearchString:"",
        //分頁控制
        CurrenPage: 1,
        PageSize: 3,
        AppointPage: 1,
    },
    methods: {
        initNewOrUpdateCustermer() {
            this.NewOrUpdateCustermer.Id = 0;
            this.NewOrUpdateCustermer.CustomerName = "";
            this.NewOrUpdateCustermer.Phone = "";
            this.NewOrUpdateCustermer.Address = "";
        },
        GetCustomerList() {
            that = this;
            $.ajax({
                type: 'get',
                url: '/api/Customers/GetCustomerList',
                data: {
                },
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                dataType: 'json',
                success: function (result) {
                    that.CustomerInfoList = result
                },
                error: function (jqXHR, textStatus, errorThrown) {

                }
            })
        },
        GetCustomerDetail(Id) {
            that = this;
            $.ajax({
                type: 'get',
                url: '/api/Customers/GetCustomerDetail',
                data: {
                    'Id': Id
                },
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                dataType: 'json',
                success: function (result) {
                    that.NewOrUpdateCustermer = result;
                    $('#create').modal('show');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    swal(jqXHR.responseText, '', 'error')
                }
            })
        },
        CreateCustomer() {
            that = this;
            $.ajax({
                type: 'post',
                url: '/api/Customers/CreateCustomer',
                data: {
                    'CustomerName': that.NewOrUpdateCustermer.CustomerName,
                    'Phone': that.NewOrUpdateCustermer.Phone,
                    'Address': that.NewOrUpdateCustermer.Address
                },
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                dataType: 'json',
                success: function (result) {
                    $('.modal').modal('hide');
                    that.CustomerInfoList = result;
                    swal('新增成功', '', 'success');
                    //swal('新增成功', '', 'success').then(function () {
                    //    window.location.href = '/Home/CustomerList';
                    //})
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    swal(jqXHR.responseText,'','error')
                }
            })
        },
        UpdateCustomer() {
            swal('是否修改此筆資料', {
                icon: "warning",
                buttons: true,
                dangerMode: true,
            }).then(res => {
                console.log(res)
                if (!res) return;
            })
            that = this;
            var test = that.NewOrUpdateCustermer;
            debugger;
            $.ajax({
                type: 'put',
                url: '/api/Customers/UpdateCustomer',
                data: {
                    'Id': that.NewOrUpdateCustermer.Id,
                    'CustomerName': that.NewOrUpdateCustermer.CustomerName,
                    'Phone': that.NewOrUpdateCustermer.Phone,
                    'Address': that.NewOrUpdateCustermer.Address
                },
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                dataType: 'json',
                success: function (result) {
                    $('.modal').modal('hide');
                    that.CustomerInfoList = result;
                    swal('修改成功', '', 'success');
                    //swal('修改成功', '', 'success').then(function () {
                    //    window.location.href = '/Home/CustomerList';
                    //})
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    swal(jqXHR.responseText, '', 'error')
                }
            })
        },
        DeleteCustomer(Id) {
            that = this;
            debugger;
            swal('是否刪除此筆資料', {
                icon: "warning",
                buttons: true,
                dangerMode: true,
            }).then(res => {
                if (!res) return;
                $.ajax({
                    type: 'Delete',
                    url: '/api/Customers/DeleteCustomer/'+Id,
                    data: {
                        //'Id': Id
                    },
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    dataType: 'json',
                    success: function (result) {
                        $('.modal').modal('hide');
                        that.CustomerInfoList = result;
                        swal('刪除成功', '', 'success');
                        //swal('修改成功', '', 'success').then(function () {
                        //    window.location.href = '/Home/CustomerList';
                        //})
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        swal(jqXHR.responseText, '', 'error')
                    }
                })
            })
        },
        SetPage(page) {
            if (page >= 1 && page <= this.TotalPage) {
                this.CurrenPage = parseInt(page);
            } else {
                swal('無此頁數', '', 'error');
            }
        }
    },
    mounted() {
        this.GetCustomerList();
    },
    computed: {
        TotalPage: {
            get: function () {
                if (this.CustomerInfoList.length !== 0) {
                    return Math.ceil(this.CustomerInfoList.length / this.PageSize);
                }
                return 1;
            }
        },
        PageCustomerInfoList: {
            get: function () {
                if (this.CustomerInfoList.length > this.PageSize) {
                    return this.CustomerInfoList.slice((this.CurrenPage - 1) * this.PageSize, this.CurrenPage * this.PageSize)
                } else {
                    return this.CustomerInfoList;
                }
            }
        }
    }
})