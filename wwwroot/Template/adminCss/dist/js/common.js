
  (function ($) {
    $.ajaxSetup({ cache: false });
    $.wizard = {};

    $.fn.serializeFormJSON = function () {
      var o = {};
      var a = this.serializeArray();
      $.each(a, function () {
        if (o[this.name]) {
          if (!o[this.name].push) {
            o[this.name] = [o[this.name]];
          }
          o[this.name].push(this.value || '');
        } else {
          o[this.name] = this.value || '';
        }
      });
      return o;
    };


    $.objectifyForm = function (formArray) {//serialize data function
      var returnArray = {};
      for (var i = 0; i < formArray.length; i++) {
        var value = formArray[i]['value'];
        var input = $('input[name="' + formArray[i]['name'] + '"]');
        if (input.is(':checkbox')) {
          value = value === 'on';
        }
        returnArray[formArray[i]['name']] = value;
      }
      return returnArray;
    }

  })(jQuery);
