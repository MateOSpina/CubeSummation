var baseUrl = 'http://localhost:51344/api/';
var intMaxValue = 2147483647;
var intMinValue = -2147483648;
var textInput = "";
var textOutput = "";

$(document).ready(function(){
    GetQueriesType();
    HideControls();

    $("#btnTestCase").click(function(){        
        $.post(baseUrl +"TestCases",
            {
                Cases: $("#txtTestCase").val()
            },
            function(data, status){
                var id= data.Id;
                if (id == 0)
                {
                    SetMessage("An error has ocurred!", true);
                }
                else if(id == intMaxValue)
                {
                    SetMessage("The last test case created have pending cases!", true);
                }
                else
                {
                    SetMessage("Test case created!", false);
                    textInput += "\n" + data.Cases;
                    $("#txtInputs").val(textInput);
                }

                CleanControls();
            }
        );
    });

    $("#btnMatriz").click(function(){
        $.post(baseUrl +"Matrizs",
            {
                Matriz: {
                    Operations: parseInt($("#txtMatrizOperations").val())
                },
                NumberOfRows: parseInt($("#txtMatrizNumberOfRows").val())
            },
            function(data, status){
                var id= data.Id;
                if (id == 0)
                {
                    SetMessage("An error has ocurred!", true);
                }
                else if(id == intMaxValue)
                {
                    SetMessage("The last matriz created have pending executions!", true);
                }
                else if (id == intMinValue)
                {
                    SetMessage("You need create a new test case!", true);
                }
                else
                {
                    SetMessage("Matriz created!", false);
                    textInput += "\n" + $("#txtMatrizNumberOfRows").val() + " " + $("#txtMatrizOperations").val();
                    $("#txtInputs").val(textInput);
                }

                CleanControls();
            }
        );
    });

    $("#ddlQueryType").change(function(){
        var selectedValue = $("#ddlQueryType").val();
        if (selectedValue){
            switch(selectedValue){
                case "1":
                    $("#QueryControls").hide();
                    $("#UpdateControls").show();
                    break;
                case "2":
                    $("#QueryControls").show();
                    $("#UpdateControls").hide();
                    break;
            }
        }
        else{
            HideControls();
        }
    });

    $("#btnSendUpdate").click(function(){
        $.post(baseUrl +"ExecuteQuery",
            {
                QueryType: $("#ddlQueryType").val(),
                NumberOfRow: parseInt($("#txtUpdateRow").val()),
                Value: parseInt($("#txtUpdateValue").val())
            },
            function(data, status){
                if (data)
                {
                    textInput += "\n"+  $("#txtUpdateRow").val() + " " + $("#txtUpdateRow").val() + " " + $("#txtUpdateRow").val() + " " + $("#txtUpdateValue").val();
                    $("#txtInputs").val(textInput);
                    SetMessage("Update Executed!", false);
                }
                else{
                    SetMessage("The Matriz have no operations to do. You need creeate new Matriz!", true);
                }

                CleanControls();
                HideControls();
        });
    });

    $("#btnSendQuery").click(function(){
        $.post(baseUrl +"ExecuteQuery",
            {
                QueryType: $("#ddlQueryType").val(),
                NumberOfRow: parseInt($("#txtInitial").val()),
                NumberOfEndRow: parseInt($("#txtEnd").val())
            },
            function(data, status){
                if (data || data == 0)
                {
                    textInput += "\n" + $("#txtInitial").val() + " " + $("#txtInitial").val() + " " + $("#txtInitial").val() + " " + $("#txtEnd").val() + " " + $("#txtEnd").val() + " " + $("#txtEnd").val();
                    $("#txtInputs").val(textInput);
                    textOutput += "\n" + data;
                    $("#txtResults").val(textOutput);
                    SetMessage("Query Executed!", false);
                }
                else{
                    SetMessage("The Matriz have no operations to do. You need create new Matriz!", true);
                }

                CleanControls();
                HideControls();
        });
    });
});

function GetQueriesType()
{
    $.get(baseUrl + 'GetQueriesType',
        function(data, status){
            var $select = $('#ddlQueryType');
            $select.find('option').remove();  
            $select.append('<option value="0">Select</option>');
            $.each(data,function(key, value) 
            {
                $select.append('<option value=' + value.id + '>' + value.name + '</option>');
            });
        }
    );
}

function SetMessage(text, isError) {
    var label = $("#lblMessage");
    label.text(text);
    if (!isError)
    {
        label.css("color", '#58FF33');
    }
    else{
        label.css('color', '#FF3342');
    }
}

function HideControls()
{
    $("#QueryControls").hide();
    $("#UpdateControls").hide();
}

function CleanControls(){
    $("#txtInitial").val("");
    $("#txtEnd").val("");
    $("#txtUpdateRow").val("");
    $("#txtUpdateValue").val("");
    $("#txtTestCase").val("");
    $("#txtMatrizOperations").val("");
    $("#txtMatrizNumberOfRows").val("");
    $("#ddlQueryType").val("0");
}

function MinMaxValidation(value, min, max) 
{
    if(parseInt(value) < min || isNaN(parseInt(value))) 
        return min; 
    else if(parseInt(value) > max) 
        return max; 
    else return value;
}