1. web.config'e bunu ekle:

<system.webServer>
...
      <modules>
	<remove name="WebDAVModule" />
      </modules>
      <handlers>
        ...
	<remove name="WebDAV" />
      </handlers>
...
</system.webServer>

2. Connection stringin: CHARSET=utf8; olmalı



