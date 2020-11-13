jQuery(document).ready(function() {
    $(".nav-top-iconmenu").click(function(){
        $(".nav-top").toggle();
    });
    $(".dot-dot").dotdotdot({
    });

    $("#che").click(function(){        
        $("." + $("#che").attr('searchId')).click();
    })
    $(".dltn").click(function(){  
    	$(".bg-dltn").toggle(1, function() {
		    if($(this).is(':hidden')) { 
		        $(".a").removeClass('bg-black');
                $("#che").attr("searchId", "dltn");
		        $("#form-search").css("z-index","initial");
		    	$("#form-search").css("position","initial");
		    	$("#form-search").css("background","#f1f1f1");
		    }
		    else {
		        $(".a").addClass('bg-black ');
                $("#che").attr("searchId", "dltn");
		    	$("#form-search").css("z-index","9999");
		    	$("#form-search").css("position","relative");
		    	$("#form-search").css("background","initial");
		    }

		});
    	if($(".bg-dlnn").css("display","none")) {
    		
    	}else{
    		$(".bg-dlnn").css("display","none");
    	}

    	if($(".bg-dltt").css("display","none")) {
    		
    	}else{
    		$(".bg-dltt").css("display","none");
    	}

        if($(".bg-dltc").css("display","none")) {
            
        }else{
            $(".bg-dltc").css("display","none");
        }
        event.stopPropagation(); 
    });

    $(".dlnn").click(function(){
    	$(".bg-dlnn").toggle(1, function() {
		    if($(this).is(':hidden')) { 
		        $(".a").removeClass('bg-black');
                $("#che").attr("searchId", "");
		        $("#form-search").css("z-index","initial");
		    	$("#form-search").css("position","initial");
		    	$("#form-search").css("background","#f1f1f1");
		    }
		    else {
		        $(".a").addClass('bg-black ');
                $("#che").attr("searchId", "dlnn");
		    	$("#form-search").css("z-index","9999");
		    	$("#form-search").css("position","relative");
		    	$("#form-search").css("background","initial");
		    }
		});
    	if($(".bg-dltn").css("display","none")) {
    		
    	}else{
    		$(".bg-dltn").css("display","none");
    	}
    	if($(".bg-dltt").css("display","none")) {
    		
    	}else{
    		$(".bg-dltt").css("display","none");
    	}
        if($(".bg-dltc").css("display","none")) {
            
        }else{
            $(".bg-dltc").css("display","none");
        }
    });
    $(".tttc").click(function(){
    	$(".bg-dltt").toggle(1, function() {
		    if($(this).is(':hidden')) { 
		        $(".a").removeClass('bg-black');
                $("#che").attr("searchId", "");
		        $("#form-search").css("z-index","initial");
		    	$("#form-search").css("position","initial");
		    	$("#form-search").css("background","#f1f1f1");
		    }
		    else {
		        $(".a").addClass('bg-black ');
                $("#che").attr("searchId", "tttc");
		    	$("#form-search").css("z-index","9999");
		    	$("#form-search").css("position","relative");
		    	$("#form-search").css("background","initial");
		    }
		});
    	if($(".bg-dlnn").css("display","none")) {
    		
    	}else{
    		$(".bg-dlnn").css("display","none");
    	}
    	if($(".bg-dltn").css("display","none")) {
    		
    	}else{
    		$(".bg-dltn").css("display","none");
    	}
        if($(".bg-dltc").css("display","none")) {
            
        }else{
            $(".bg-dltc").css("display","none");
        }
    });
    $(".dltc").click(function(){
        $(".bg-dltc").toggle(1, function() {
            if($(this).is(':hidden')) { 
                $(".a").removeClass('bg-black');
                $("#che").attr("searchId", "");
                $("#form-search").css("z-index","initial");
                $("#form-search").css("position","initial");
                $("#form-search").css("background","#f1f1f1");
            }
            else {
                $(".a").addClass('bg-black ');
                $("#che").attr("searchId", "tttc");
                $("#form-search").css("z-index","9999");
                $("#form-search").css("position","relative");
                $("#form-search").css("background","initial");
            }
        });
        if($(".bg-dlnn").css("display","none")) {
            
        }else{
            $(".bg-dlnn").css("display","none");
        }
        if($(".bg-dltn").css("display","none")) {
            
        }else{
            $(".bg-dltn").css("display","none");
        }
        if($(".bg-dltt").css("display","none")) {
            
        }else{
            $(".bg-dltt").css("display","none");
        }
    });
    $(".social-bot").click(function(event) {
      if($(".social-bot").hasClass("show1")) {
        $(".social-top").addClass("hidden");
        $(".social-top").removeClass("show");
        $(".social-bot").addClass("show2");
        $(".social-bot").removeClass("show1");
      }else{  
        $(".social-top").addClass("show");
        $(".social-top").removeClass("hidden");
        $(".social-bot").addClass("show1");
        $(".social-bot").removeClass("show2");
      }
    });
});
/*$(document).ready(function(){
    $(' .carousel[data-type="multi"] .item').each(function(){
      var next = $(this).next();
      if (!next.length) {
        next = $(this).siblings(':first');
      }
      next.children(':first-child').clone().appendTo($(this));
      
      for (var i=0;i<2;i++) {
        next=next.next();
        if (!next.length) {
            next = $(this).siblings(':first');
        }
        
        next.children(':first-child').clone().appendTo($(this));
      }
    });
});*/
