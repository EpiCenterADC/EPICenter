
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
  $('#banners').cycle({ 
	    fx:     'fade',
	    timeout: 5000,
	    pager:  '#bannerNav',
	    speed: 1000,
	    fit: 0
	});
	
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
			
		
		
			var rowCount = $('#itsTable tbody tr').length;
					
			
			 //Add the row
//			 var tbl = $('#itsTable').DataTable();
				$('#its').on( 'click', function () {
					alert("Adding new rows");
					for(var i=0;i<=4;i++){
					tbl.row.add( 
					 [++rowCount,'Week','<input class="date" type="text" name="date"/>','<select class="project" name="project" ><option value="p1">Project Summary</option><option value="p2">MHC</option><option value="p3">SLL</option><option value="p4">Alfa Laval</option><option value="p4">E.ON</option></select>','<input class="case" type="text" name="case"/>','<input class="title" type="text" name="title"/>','<select class="task" name="task" > <option value="t1">t1</option> <option value="t2">t2</option> <option value="t3">t3</option><option value="t4">t4</option></select>','<input class="actualHours" type="text" name="actualHours"/>','<input class="billableHours" type="text" name="billableHours"/>','<input class="description" type="text" name="description"/>','<input class="comment" type="text" name="comment"/>','<a class="delete" href="#" title="Delete Entire Row"></a> ']
					).draw();}
					
                  
				   
                });
				
		//Deletes Row
				$('#itsTable').on('click','.delete',function(e){
						var rowCount = $('#itsTable tbody tr').length;
						console.log(rowCount);
						if(rowCount > 1){
						tbl.row( $(this).parents('tr') ).remove().draw();
						}
						else{
							alert("Can not delete All row");
						}
						
					});
					
			
//			//AUTOCOMPLETE SCRIPT
//			$(function() {
//				var availableTags = [
//				  "Amol Joshi",
//				  "Abhijit Rahate",
//				  "Akshata Patil",
//				  "Amit Chugh",
//				  "Amol Mahul",
//				  "Archana Punyavant",
//				  "Asmita Ukey",
//				  "Mahesh badale",
//				  "Malik Kadiwar",
//				  "Puneet Mahajan",
//				  "Purushottam Kumar",
//				  "Sameer Bhandwalkar",
//				  "Shailandra Dukane",
//				  "Swati Patil",
//				  "Trupti Dandekar",
//				  "Vipin Karnath",
//				  "Viral Jain",
//				  "Vrinda Bhayani",
//				  "Yogesh Sandhokar",
//				  "Shashank Shinde",
//				  "Bhavesh Sachdev",
//				  "Snehal Jadhav",
//				  "Priti Jadhav",
//				  "Priyanka"
//				];
//				$("#tags1").autocomplete({
//				  source: availableTags
//				});
//			  });
//			  /* END INTERNAL TIMESHEET JAVA SCRIPT, jQUERY  */
         
						
});


 
