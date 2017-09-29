(function () {
    window.Common = Common || {};
    window.Common.Select2 = Common.Select2 || {};

    Common.Select2.formatDataDefault = function (data) {
        if (data.loading)
            return "Loading";

        return data.text;
    }


    Common.Select2.formatDataSelectionDefault = function (data) {
        return data.text;
    }

    Common.Select2.dataDefault = function (params) {
        return {
            Query: params.term, // search term
            PageSize: this.pageSize,
            PageNumber: params.page
        };
    }

    Common.Select2.initialize = function ($el) {
            if (!$el.data("select2")) {

                var args =
                    {
                        delay: Number($el.data("select2-delay")),
                        quietMillis: Number($el.data("select2-quietmillis")),
                        cache: JSON.parse($el.data("select2-cache").toLowerCase()), //can parse literals and values
                        pageSize: Number($el.data("select2-pagesize")),
                        minimumInputLength: Number($el.data("select2-minimuminputlength")),
                        templateResult: $el.data("select2-templateresult"),
                        templateSelection: $el.data("select2-templateselection"),
                        url: $el.data("select2-url"),
                        data: VNEStream.GetFunctionFromString($el.data("select2-data")),
                        containerCssClass: $el.data("select2-containercssclass"),
                        dropdownCssClass: $el.data("select2-dropdowncssclass")
                    }


                $el.select2({
                    ajax: {
                        url: args.url,
                        dataType: 'json',
                        delay: args.delay,
                        quietMillis: args.quietMillis,
                        data: (params) => {
                            return args.data(params);
                        },
                        processResults: function (response, params) {
                            return {
                                results: response.Items,
                                pagination: {
                                    more: response.HasMorePages
                                }
                            };
                        },
                        cache: args.cache
                    },
                    escapeMarkup: function (markup) { return markup; }, // It let us use HTML markup
                    minimumInputLength: args.minimumInputLength,
                    templateResult: VNEStream.GetFunctionFromString(args.templateResult),
                    templateSelection: VNEStream.GetFunctionFromString(args.templateSelection),
                    placeholder: "-- Select --",
                    containerCssClass: args.containerCssClass,
                    dropdownCssClass: args.dropdownCssClass,
                    allowClear: true
                });
            }
    };

    $(() => {
        var $selects = $("[data-Select2AjaxViewModel]");
        $.each($selects, (index, element) => {
            VNEStream.Select2.initialize($(element));
        });
    });
})();;