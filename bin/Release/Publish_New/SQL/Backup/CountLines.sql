﻿-- CountLines
SELECT COUNT(1) 
  FROM (
				  SELECT 'L1' AS Code, 'Name #1' AS Name, 'User #1' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L2' AS Code, 'Name #2' AS Name, 'User #2' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L3' AS Code, 'Name #3' AS Name, 'User #3' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L4' AS Code, 'Name #4' AS Name, 'User #4' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L5' AS Code, 'Name #5' AS Name, 'User #5' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L6' AS Code, 'Name #6' AS Name, 'User #6' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L7' AS Code, 'Name #7' AS Name, 'User #7' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L8' AS Code, 'Name #8' AS Name, 'User #8' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L9' AS Code, 'Name #9' AS Name, 'User #9' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L10' AS Code, 'Name #10' AS Name, 'User #10' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L11' AS Code, 'Name #11' AS Name, 'User #11' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L12' AS Code, 'Name #12' AS Name, 'User #12' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L13' AS Code, 'Name #13' AS Name, 'User #13' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L14' AS Code, 'Name #14' AS Name, 'User #14' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L15' AS Code, 'Name #15' AS Name, 'User #15' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L16' AS Code, 'Name #16' AS Name, 'User #16' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L17' AS Code, 'Name #17' AS Name, 'User #17' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L18' AS Code, 'Name #18' AS Name, 'User #18' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L19' AS Code, 'Name #19' AS Name, 'User #19' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L20' AS Code, 'Name #20' AS Name, 'User #20' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L21' AS Code, 'Name #21' AS Name, 'User #21' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L22' AS Code, 'Name #22' AS Name, 'User #22' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L23' AS Code, 'Name #23' AS Name, 'User #23' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L24' AS Code, 'Name #24' AS Name, 'User #24' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L25' AS Code, 'Name #25' AS Name, 'User #25' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L26' AS Code, 'Name #26' AS Name, 'User #26' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L27' AS Code, 'Name #27' AS Name, 'User #27' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L28' AS Code, 'Name #28' AS Name, 'User #28' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L29' AS Code, 'Name #29' AS Name, 'User #29' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L30' AS Code, 'Name #30' AS Name, 'User #30' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L31' AS Code, 'Name #31' AS Name, 'User #31' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L32' AS Code, 'Name #32' AS Name, 'User #32' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L33' AS Code, 'Name #33' AS Name, 'User #33' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L34' AS Code, 'Name #34' AS Name, 'User #34' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L35' AS Code, 'Name #35' AS Name, 'User #35' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L36' AS Code, 'Name #36' AS Name, 'User #36' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L37' AS Code, 'Name #37' AS Name, 'User #37' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L38' AS Code, 'Name #38' AS Name, 'User #38' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L39' AS Code, 'Name #39' AS Name, 'User #39' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L40' AS Code, 'Name #40' AS Name, 'User #40' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L41' AS Code, 'Name #41' AS Name, 'User #41' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L42' AS Code, 'Name #42' AS Name, 'User #42' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L43' AS Code, 'Name #43' AS Name, 'User #43' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L44' AS Code, 'Name #44' AS Name, 'User #44' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L45' AS Code, 'Name #45' AS Name, 'User #45' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L46' AS Code, 'Name #46' AS Name, 'User #46' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L47' AS Code, 'Name #47' AS Name, 'User #47' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L48' AS Code, 'Name #48' AS Name, 'User #48' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L49' AS Code, 'Name #49' AS Name, 'User #49' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L50' AS Code, 'Name #50' AS Name, 'User #50' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L51' AS Code, 'Name #51' AS Name, 'User #51' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L52' AS Code, 'Name #52' AS Name, 'User #52' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L53' AS Code, 'Name #53' AS Name, 'User #53' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L54' AS Code, 'Name #54' AS Name, 'User #54' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L55' AS Code, 'Name #55' AS Name, 'User #55' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L56' AS Code, 'Name #56' AS Name, 'User #56' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L57' AS Code, 'Name #57' AS Name, 'User #57' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L58' AS Code, 'Name #58' AS Name, 'User #58' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L59' AS Code, 'Name #59' AS Name, 'User #59' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L60' AS Code, 'Name #60' AS Name, 'User #60' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L61' AS Code, 'Name #61' AS Name, 'User #61' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L62' AS Code, 'Name #62' AS Name, 'User #62' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L63' AS Code, 'Name #63' AS Name, 'User #63' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L64' AS Code, 'Name #64' AS Name, 'User #64' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L65' AS Code, 'Name #65' AS Name, 'User #65' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L66' AS Code, 'Name #66' AS Name, 'User #66' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L67' AS Code, 'Name #67' AS Name, 'User #67' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L68' AS Code, 'Name #68' AS Name, 'User #68' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L69' AS Code, 'Name #69' AS Name, 'User #69' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L70' AS Code, 'Name #70' AS Name, 'User #70' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L71' AS Code, 'Name #71' AS Name, 'User #71' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L72' AS Code, 'Name #72' AS Name, 'User #72' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L73' AS Code, 'Name #73' AS Name, 'User #73' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L74' AS Code, 'Name #74' AS Name, 'User #74' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L75' AS Code, 'Name #75' AS Name, 'User #75' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L76' AS Code, 'Name #76' AS Name, 'User #76' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L77' AS Code, 'Name #77' AS Name, 'User #77' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L78' AS Code, 'Name #78' AS Name, 'User #78' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L79' AS Code, 'Name #79' AS Name, 'User #79' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L80' AS Code, 'Name #80' AS Name, 'User #80' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L81' AS Code, 'Name #81' AS Name, 'User #81' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L82' AS Code, 'Name #82' AS Name, 'User #82' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L83' AS Code, 'Name #83' AS Name, 'User #83' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L84' AS Code, 'Name #84' AS Name, 'User #84' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L85' AS Code, 'Name #85' AS Name, 'User #85' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L86' AS Code, 'Name #86' AS Name, 'User #86' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L87' AS Code, 'Name #87' AS Name, 'User #87' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L88' AS Code, 'Name #88' AS Name, 'User #88' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L89' AS Code, 'Name #89' AS Name, 'User #89' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L90' AS Code, 'Name #90' AS Name, 'User #90' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L91' AS Code, 'Name #91' AS Name, 'User #91' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L92' AS Code, 'Name #92' AS Name, 'User #92' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L93' AS Code, 'Name #93' AS Name, 'User #93' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L94' AS Code, 'Name #94' AS Name, 'User #94' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L95' AS Code, 'Name #95' AS Name, 'User #95' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L96' AS Code, 'Name #96' AS Name, 'User #96' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L97' AS Code, 'Name #97' AS Name, 'User #97' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L98' AS Code, 'Name #98' AS Name, 'User #98' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L99' AS Code, 'Name #99' AS Name, 'User #99' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L100' AS Code, 'Name #100' AS Name, 'User #100' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L101' AS Code, 'Name #101' AS Name, 'User #101' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L102' AS Code, 'Name #102' AS Name, 'User #102' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L103' AS Code, 'Name #103' AS Name, 'User #103' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L104' AS Code, 'Name #104' AS Name, 'User #104' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L105' AS Code, 'Name #105' AS Name, 'User #105' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L106' AS Code, 'Name #106' AS Name, 'User #106' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L107' AS Code, 'Name #107' AS Name, 'User #107' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L108' AS Code, 'Name #108' AS Name, 'User #108' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L109' AS Code, 'Name #109' AS Name, 'User #109' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L110' AS Code, 'Name #110' AS Name, 'User #110' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L111' AS Code, 'Name #111' AS Name, 'User #111' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L112' AS Code, 'Name #112' AS Name, 'User #112' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L113' AS Code, 'Name #113' AS Name, 'User #113' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L114' AS Code, 'Name #114' AS Name, 'User #114' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L115' AS Code, 'Name #115' AS Name, 'User #115' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L116' AS Code, 'Name #116' AS Name, 'User #116' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L117' AS Code, 'Name #117' AS Name, 'User #117' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L118' AS Code, 'Name #118' AS Name, 'User #118' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L119' AS Code, 'Name #119' AS Name, 'User #119' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L120' AS Code, 'Name #120' AS Name, 'User #120' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L121' AS Code, 'Name #121' AS Name, 'User #121' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L122' AS Code, 'Name #122' AS Name, 'User #122' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L123' AS Code, 'Name #123' AS Name, 'User #123' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L124' AS Code, 'Name #124' AS Name, 'User #124' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L125' AS Code, 'Name #125' AS Name, 'User #125' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L126' AS Code, 'Name #126' AS Name, 'User #126' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L127' AS Code, 'Name #127' AS Name, 'User #127' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L128' AS Code, 'Name #128' AS Name, 'User #128' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L129' AS Code, 'Name #129' AS Name, 'User #129' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L130' AS Code, 'Name #130' AS Name, 'User #130' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L131' AS Code, 'Name #131' AS Name, 'User #131' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L132' AS Code, 'Name #132' AS Name, 'User #132' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L133' AS Code, 'Name #133' AS Name, 'User #133' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L134' AS Code, 'Name #134' AS Name, 'User #134' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L135' AS Code, 'Name #135' AS Name, 'User #135' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L136' AS Code, 'Name #136' AS Name, 'User #136' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L137' AS Code, 'Name #137' AS Name, 'User #137' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L138' AS Code, 'Name #138' AS Name, 'User #138' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L139' AS Code, 'Name #139' AS Name, 'User #139' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L140' AS Code, 'Name #140' AS Name, 'User #140' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L141' AS Code, 'Name #141' AS Name, 'User #141' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L142' AS Code, 'Name #142' AS Name, 'User #142' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L143' AS Code, 'Name #143' AS Name, 'User #143' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L144' AS Code, 'Name #144' AS Name, 'User #144' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L145' AS Code, 'Name #145' AS Name, 'User #145' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L146' AS Code, 'Name #146' AS Name, 'User #146' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L147' AS Code, 'Name #147' AS Name, 'User #147' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L148' AS Code, 'Name #148' AS Name, 'User #148' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L149' AS Code, 'Name #149' AS Name, 'User #149' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L150' AS Code, 'Name #150' AS Name, 'User #150' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L151' AS Code, 'Name #151' AS Name, 'User #151' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L152' AS Code, 'Name #152' AS Name, 'User #152' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L153' AS Code, 'Name #153' AS Name, 'User #153' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L154' AS Code, 'Name #154' AS Name, 'User #154' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L155' AS Code, 'Name #155' AS Name, 'User #155' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L156' AS Code, 'Name #156' AS Name, 'User #156' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L157' AS Code, 'Name #157' AS Name, 'User #157' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L158' AS Code, 'Name #158' AS Name, 'User #158' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L159' AS Code, 'Name #159' AS Name, 'User #159' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L160' AS Code, 'Name #160' AS Name, 'User #160' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L161' AS Code, 'Name #161' AS Name, 'User #161' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L162' AS Code, 'Name #162' AS Name, 'User #162' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L163' AS Code, 'Name #163' AS Name, 'User #163' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L164' AS Code, 'Name #164' AS Name, 'User #164' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L165' AS Code, 'Name #165' AS Name, 'User #165' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L166' AS Code, 'Name #166' AS Name, 'User #166' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L167' AS Code, 'Name #167' AS Name, 'User #167' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L168' AS Code, 'Name #168' AS Name, 'User #168' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L169' AS Code, 'Name #169' AS Name, 'User #169' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L170' AS Code, 'Name #170' AS Name, 'User #170' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L171' AS Code, 'Name #171' AS Name, 'User #171' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L172' AS Code, 'Name #172' AS Name, 'User #172' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L173' AS Code, 'Name #173' AS Name, 'User #173' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L174' AS Code, 'Name #174' AS Name, 'User #174' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L175' AS Code, 'Name #175' AS Name, 'User #175' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L176' AS Code, 'Name #176' AS Name, 'User #176' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L177' AS Code, 'Name #177' AS Name, 'User #177' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L178' AS Code, 'Name #178' AS Name, 'User #178' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L179' AS Code, 'Name #179' AS Name, 'User #179' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L180' AS Code, 'Name #180' AS Name, 'User #180' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L181' AS Code, 'Name #181' AS Name, 'User #181' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L182' AS Code, 'Name #182' AS Name, 'User #182' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L183' AS Code, 'Name #183' AS Name, 'User #183' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L184' AS Code, 'Name #184' AS Name, 'User #184' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L185' AS Code, 'Name #185' AS Name, 'User #185' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L186' AS Code, 'Name #186' AS Name, 'User #186' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
			UNION SELECT 'L187' AS Code, 'Name #187' AS Name, 'User #187' AS CreatedBy, GETUTCDATE() AS CreatedDate, 'User #3' AS ChangedBy, GETUTCDATE() AS ChangedDate
  ) AS DATA
  WHERE		Code LIKE '%'+ ISNULL(@Code,'') +'%' 
	OR		Name LIKE '%'+ ISNULL(@Code,'') +'%' 