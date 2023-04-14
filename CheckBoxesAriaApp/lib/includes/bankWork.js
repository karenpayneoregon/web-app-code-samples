$(document).ready(function() {
	if (window.matchMedia('(prefers-color-scheme)').media === 'not all') {
	  console.log('Browser doesn\'t support dark mode');
	}else
	{
		console.log('Browser does support dark mode');
	}
	$('<div id="headAlert" class="alert alert-primary text-center" role="alert">Bank data via ajax</div>').appendTo(document.body);

	var bankValue = 'ga';

    $.ajax(
    {
		type: "GET",
        url: "dataOperations.cfc?method=getBank&returnformat=json", data: "bankName=" + bankValue,
        dataType: "json"
    })
    .done(function (response) {
		var stringBuilder = '<table class="table table-sm"><thead class="thead-dark"><tr>';
        var index;


        for (index = 0; index < response.COLUMNS.length; index++) {
          stringBuilder += '<th scope="col">' + response.COLUMNS[index].replace(/_/g, ' ') + '</th>';
      	}

		stringBuilder += '</tr>';

        for (index = 0; index < response.DATA.length; index++) {
          stringBuilder += '<tr>';
          //loop over each column
          for (colIndex = 0; colIndex < response.DATA[index].length; colIndex++) {
              stringBuilder += '<td>' + response.DATA[index][colIndex] + '</td>';
          }
          stringBuilder += '</tr></thead>';
        }

	    stringBuilder += '</table>';
	    
		$(stringBuilder).appendTo(document.body);

    })
        .fail(function (jqHXR, status, error) {
            $('#results').html("<p>Sorry! Something's wrong...<br /> Error: " + status + "</p>");
        });
});