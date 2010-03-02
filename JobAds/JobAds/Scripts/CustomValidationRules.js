Sys.Mvc.ValidatorRegistry.validators["ExcludedWords"] = function(rule) {
    var words = rule.ValidationParameters.words;
    var message = rule.ErrorMessage;

    return function(value) {
        for (var i = 0; i < words.length; i++) {
            if (value.indexOf(words[i]) >= 0)
                return message.replace("{0}", words[i]);
        }
        return true;
    }
}