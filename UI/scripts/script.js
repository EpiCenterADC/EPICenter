
$(document).ready(function() {
  
	$('.mainBody').css('min-height',eval($(window).height() - $('.head').height() - $('.footer').height() -20));

   //New Ticker stop on mouseover
   $('#newsTicker marquee').hover(function(){
   		this.stop();
   },
   function(){
   		this.start();
   });

   //Banner 
//  $('#banners').cycle({ 
//	    fx:     'fade',
//	    timeout: 5000,
//	    pager:  '#bannerNav',
//	    speed: 1000,
//	    fit: 0
//	});
	
  // Add class to diffrenciate home page and other pages.	
    var pageClass = (!$('#topnav li').first().hasClass('active')) ? 'innerPage' :  'homePage' ;
  	$('body').addClass(pageClass);

	// Click Toggle
	$.fn.clickToggle = function(a,b) {
	  var ab=[b,a];
	  function cb(){ ab[this._tog^=1].call(this); }
	  return this.on("click", cb);
	};

  	$('.profileCont .editButton .button').clickToggle(
  		function(){
  			$('.profileCont').find('.label').hide();
  			$('.profileCont').find('.inputField').show();
  		},
  		function(){
  			$(this).attr('type','submit');
  			$('.profileCont').find('.inputField').hide();
  			$('.profileCont').find('.label').show();
  		}
  	);
	
	//Poll
 	 $('.pollCont button').prop('disabled', 'disabled').addClass('disabled');
      
      $('.pollCont input[name="Response"]').click(function(){
           $('.pollCont button').prop('disabled', '').removeClass('disabled');
			 $('.pollCont input[name="Response"]').parent().removeClass('selected');
			 $(this).parent().addClass('selected');
      });

      //Generate Poll Result Graph on vote button click
      $('.pollButtonCont input[type="submit"]').click(function(e){
        e.preventDefault();
        var form = $(this).closest('form');
        showPollResult(form);
      });
     
      //If user has already voted
      if($('.pollQuestionCont').length == 0){
        $('.pollResultCont').html("Loading Poll Result...").removeClass('hide');
        var form = $('.pollCont form');
        showPollResult(form);
      }

       //Generate Poll Result Graph
      function showPollResult(form){
        var formUrl = $(form).attr('action');
        
        $.ajax({
            url:formUrl,
            dataType:'json',
            data:$(form).serialize(),
            type:"POST",
            beforeSend:function(){
              $('.pollResultCont').html("Loading Poll Result...").removeClass('hide');
              $('.pollCont input[type="submit"]').prop('disabled', 'disabled').addClass('disabled');
            },
            success: function(data, status, xhr) {
              	var res = "", percent = [] ;
				$.each(data.pollAnswer, function(index, value) {
					percent[index] = eval((100*data.pollAnswer[index].votes)/data.totalVotes);
					
					res+= '<li id="pollQuest'+index+'"><div class="pollQ">'+data.pollAnswer[index].answer+'</div><div class="pollQGraph"><span>'+data.pollAnswer[index].votes+'</span></div></li>';
				});
				$('.pollQuestionCont,.pollButtonCont').hide();
				$('.pollResultCont').html(res).removeClass('hide');

				$('.pollQGraph span').each(function(ind){
				    $(this).animate({
				      width:percent[ind]+"%",
				    },1000).css('display','block');
				});
            },
           error: function(err, status, xhr) {
              console.log(err);
           }
        });
      }
      //Poll
	/*  INTERNAL TIMESHEET JAVA SCRIPT, jQUERY  */
	
	
//            	$('#itsTable').dataTable( {
//				    "bPaginate": false,
//				    "bInfo": false
//				  } );
//				$('#utlTable').dataTable();
			
		
		var rowCount;
				

				$('#addBtn').on('click',function(){
									
				rowCount= $('#itsTable tbody tr').length;
				for(var i=0; i<=4; i++){
				$("#itsTable tr:last").after("<tr>"+ 
					"<td class='sno' scope='row'>"+ ++rowCount +"</td>" +
					"<td>Week no</td>" +
				    "<td><select class='aa'></select></td>"+
					"<td><select class='addrowproject' name='project'></td>"+
					"<td>"+
					"<input class='case' type='text' name='case'/>"+"</td>"+
					"<td><input class='title' type='text' name='title'/></td>"+
					"<td><select class='addrowtask' name='task'></td>"+
				    "<td><input class='actualHours' type='text' name='actualHours'/>"+"</td>"+
					"<td><input class='billableHours' type='text' name='billableHours'/>"+
					"</td>"+
					"<td><input class='description' type='text' name='description'/>"+"</td>"+
					"<td><input class='comment' type='text' name='comment'/>"+"</td>"+
					"<td><a class='delete' href='#'' title='Delete Entire Row'></a>"+"</td>"+
					"</tr>");
					}


                    binddrpdays($('.abc').val(),$('#txtYear').val());
							 bindDropDownProject();
         bindDropDownTaskPages();		
									
				});
								

				
							$('#itsTable').on('click','.delete',function(e){
							alert("delete");
							rowCount= $('#itsTable tbody tr').length;
							
								var tr = $(this).closest('tr');
						        tr.css("background-color","#FF3700");
						        tr.fadeOut(400, function(){
						        	if(rowCount > 2){
						            tr.remove();
						        }
						        else{
						        	alert("Can Not delete All Rows");
						        }
						        });
						   
						        return false;

							});

         
         $('.abc').on('change',function(){
         var a  = $('.abc').val();
         var b = $('#txtYear').val();

         binddrpdays(a,b);
        

        
         });


            function binddrpdays(a,b){
            alert(a+','+b);

                $.ajax({
                    url: "selectDateForSelectedWeek",
                    data: {       
                        'year': b,
                        'weeknumber': a    
                    },
                    dataType: "json",
                    type: 'POST',
                    success: function (data) {
                        $('.cc').empty();
                        $.each(data, function(index, value) {
                        $('.cc,.aa').append($('<option>').text(value).attr('value', index));
                        });
                    },
                    error: function () {
                        alert("error");
                    }
                });
                };

                function bindDropDownProject(){

                $.ajax({
                    url: "bindDropDownProject",
                    
                    dataType: "json",
                    type: 'POST',
                    success: function (data) {
                    alert(data);
                        $('.addrowproject').empty();
                        $.each(data, function(index, value) {
                        $('.addrowproject').append($('<option>').text(value).attr('value', index));
                        });
                    },
                    error: function () {
                        alert("error");
                    }
                });
                };

                function bindDropDownTaskPages(){

                $.ajax({
                    url: "bindDropDownTaskPages",
                    dataType: "json",
                    type: 'POST',
                    success: function (data) {
                    alert(data);
                        $('.addrowtask').empty();
                        $.each(data, function(index, value) {
                        $('.addrowtask').append($('<option>').text(value).attr('value', index));
                        });
                    },
                    error: function () {
                        alert("error");
                    }
                });

          }
     
						
});