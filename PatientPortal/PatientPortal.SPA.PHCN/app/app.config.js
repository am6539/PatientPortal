﻿'use strict';

angular.
module('spaPHCN')
    .config(['$routeProvider', '$locationProvider', '$logProvider', '$compileProvider',
    function ($routeProvider, $locationProvider, $logProvider, $compileProvider) {
        $logProvider.debugEnabled(true);
        $locationProvider.html5Mode(true).hashPrefix('!'); //the hashPrefix is for SEO
        $compileProvider.debugInfoEnabled(false);
        $routeProvider
            .when('/', {
                templateUrl: "app/components/home-page/home-page.template.html",
                controller: "HomeController"
            })
            .when('/career', {
                templateUrl: "app/components/career/career.template.html",
                controller: "CareerController"
            })
            .when('/about', {
                templateUrl: "app/components/about/about.template.html",
                controller: "AboutController"
            })
            .when('/department', {
                templateUrl: "app/components/department/department.template.html",
                controller: "DepartmentController"
            })
            .when('/department/:id', {
                templateUrl: "app/components/department-detail/department-detail.template.html",
                controller: "DepartmentDetailController"
            })
            .when('/posts', {
                templateUrl: "app/components/posts/posts.template.html",
                controller: "PostsController"
            })
            .when('/post/:id', {
                templateUrl: "app/components/post-detail/post-detail.template.html",
                controller: "PostDetailController"
            })
            .when('/post-list/:id', {
                templateUrl: "app/components/post-list/post-list.template.html",
                controller: "PostListController"
            })
            .when('/contact', {
                templateUrl: "app/components/contact/contact.template.html",
                controller: "ContactController"
            })
            .when('/feature', {
                templateUrl: "app/components/feature/feature.template.html",
                controller: "FeatureController"
            })
            .when('/feature/:id', {
                templateUrl: "app/components/feature-detail/feature-detail.template.html",
                controller: "FeatureDetailController"
            })
            .when('/answer-question', {
                templateUrl: "app/components/answer-question/answer-question.template.html",
                controller: "AnswerQuestionController"
            })
            .when('/appointment', {
                templateUrl: "app/components/appointment/appointment.template.html",
                controller: "AppointmentController"
            })
            .when('/doctors', {
                templateUrl: "app/components/doctor-list/doctor-list.template.html",
                controller: "DoctorListController"
            })
            .when('/search/:searchText', {
                templateUrl: "app/components/search/search.template.html",
                controller: "SearchController"
            })
            .otherwise('/');
    }]);