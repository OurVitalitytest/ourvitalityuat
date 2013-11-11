/*****************************************************************************
** 
** Name: validate_fields(); 
** Description:  A common function to validate the forms
** Author: 		Parminder Singh Ubhi
** Create Date: 23-June-2110
** Updated:     29-June-2010 (fixed first field empty and other filled bug)
******************************************************************************/
function validate_fields(fields,divs)
{
	var res = true;
	for (key in fields)
	{
		if(key == 'each')
		break;
		
		if( check_fields (fields[key],divs[key]) == false )
  			 var res = false;
	}
	
	return res;
}


function check_fields(field_id,span_name)
{	
		/* alert(field_id);
		alert(span_name); */
	if (document.getElementById(field_id).value.length != 0)
	  {
			document.getElementById(span_name).style.visibility = 'hidden';
			document.getElementById(span_name).style.position = 'absolute';
			return true;
	  }
	  else
	  {
		document.getElementById(span_name).style.visibility = 'visible';
		document.getElementById(span_name).style.position = 'static';
		return false;
	  }
}

/**************************************************************************
** Name: validate_radio();
** Description: to validate radio buttons
** Create Date: 16-Oct-2110
** Updated:
**************************************************************************/

function validate_radio(field_id,span_name)
{
	if(document.getElementById(field_id).checked != false)
	  {
		if(span_name != "")
		{
	  		document.getElementById(span_name).style.visibility = 'hidden';
			document.getElementById(span_name).style.position = 'absolute';
		}
		return true;
	  }
	  else
	  {
		if(span_name != "")
		{
			document.getElementById(span_name).style.visibility = 'visible';
			document.getElementById(span_name).style.position = 'static';
		}
		return false;
	  }
}

function check_dropdownfields(field_id,span_name)
{
  if (document.getElementById(field_id).value != 0)
  {
	document.getElementById(span_name).style.visibility = 'hidden';
	document.getElementById(span_name).style.position = 'absolute';
	return true;
  }
  else
  {
	document.getElementById(span_name).style.visibility = 'visible';
	document.getElementById(span_name).style.position = 'static';
	return false;
  }
}

/* Added 2nd March 08 - samir */
function checkmail(email_field,span_name)  
{  
	var emailfilter=/^\w+[\+\.\w-]*@([\w-]+\.)*\w+[\w-]*\.([a-z]{2,4}|\d+)$/i  
	var returnval=emailfilter.test(document.getElementById(email_field).value)  
	
	if (returnval==false)  
	{  
		document.getElementById(span_name).style.visibility = 'visible';  
		document.getElementById(span_name).style.position = 'static';
		return false;  
	}  
	else  
	{
		document.getElementById(span_name).style.visibility = 'hidden';
		document.getElementById(span_name).style.position = 'absolute';	
		return true;
	}
}  
	
function checkInteger(num_field,num_div)
{
	var IsFound = /^-?\d+$/.test(document.getElementById(num_field).value);
	
	if(document.getElementById(num_field).value!="")
	{
		if (IsFound==false)
		{
			document.getElementById(num_div).style.visibility = 'visible';
			document.getElementById(num_div).style.position = 'static';
			return false;
		}
		else
		{
			document.getElementById(num_div).style.visibility = 'hidden';
			document.getElementById(num_div).style.position = 'absolute';
			return true;
		}
	}
	else
	{
		return true;
	}
}

/*function check_image(field_id)*/
function check_image(field_id,span_name)
{
	if (document.getElementById(field_id).value.length != 0)
	{
		var ext = document.getElementById(field_id).value;
		ext = ext.substring(ext.length-3,ext.length);
 		ext = ext.toLowerCase();
 		if(ext == 'peg')
 		{
 			var ext = document.getElementById(field_id).value;
			ext = ext.substring(ext.length-4,ext.length);
 			ext = ext.toLowerCase();
 		}
		if((ext != 'jpg') && (ext != 'gif') && (ext != 'png')&& (ext != 'jpeg') )
		 {

  			document.getElementById(span_name).style.visibility = 'visible';
			document.getElementById(span_name).style.position = 'static';
			return false;
   		 }
 		 else
		 {

			document.getElementById(span_name).style.visibility = 'hidden';
			document.getElementById(span_name).style.position = 'absolute';
			return true;	
		 }
	}
	else
	{

  		document.getElementById(span_name).style.visibility = 'visible';
		document.getElementById(span_name).style.position = 'static';

		return false;
	}
}


function check_checkbox(span_name)
{
  if (!document.joinmfc.iaccept.checked)
  {
	document.getElementById(span_name).style.visibility = 'visible';
	document.getElementById(span_name).style.position = 'static';
	return false;
  }
  else
  {
	document.getElementById(span_name).style.visibility = 'hidden';
	document.getElementById(span_name).style.position = 'absolute';
	return true;
  }
}

function checknum(field_name,span_name)
{
	var checknumval = isNaN(document.getElementById(field_name).value);
	if(checknumval == false && document.getElementById(field_name).value.length != '')
	{ 
		document.getElementById(span_name).style.visibility = 'visible';
		document.getElementById(span_name).style.position = 'static';	
		return false; 		
	}
	else
	{
		document.getElementById(span_name).style.visibility = 'hidden';
		document.getElementById(span_name).style.position = 'absolute';
		return true;
	} 
		
}